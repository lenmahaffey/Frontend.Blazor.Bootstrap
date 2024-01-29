pipeline {
    agent any
    stages {
        stage('Clean Workspace') {
            steps {
                script {
                    now = new Date()
                    currentBuild.displayName = 'frontend.blazor.bootstrap - ' + now.format("yyyy-MM-dd HH:mm")
                }
                cleanWs()
            }
        }
        stage('Clone Repository') {
            steps {
                git credentialsId: 'github', url: 'git@github.com:lenmahaffey/frontend.blazor.bootstrap.git'
            }
        }
        
        stage('Clean Project') {
            steps {
                dotnetClean sdk: '8.0'
            }
        }
        
        stage ('Dotnet Tool Restore') {
          steps {
                dotnetToolRestore sdk: '8.0', toolManifest: 'src/.config/dotnet-tools.json'
            }
        }
        
        stage ('NuGet Package Restore') {
          steps {
                dotnetRestore sdk: '8.0'
            }
        }
        
        stage ('Build') {
          steps {
                dotnetBuild  sdk: '8.0'
            }
        }
        
        stage ('Test') {
          steps {
                dotnetTest  noBuild: true, logger: 'trx', resultsDirectory: './TestResults', sdk: '8.0'
            }
        }
        
        stage ('Publish') {
          steps {
                dotnetPublish noBuild: true, outputDirectory: './build', sdk: '8.0', selfContained: false
            }
        }
        
        stage ('Archive') {
            steps{
                archiveArtifacts artifacts: 'build/*', followSymlinks: false
            }
        }
        
        stage ('Testing Report') {
            steps{
                mstest testResultsFile:"**/*.trx", keepLongStdio: true
            }
        }
        
        stage ('Build Docker Container'){
            steps{
                script{
                    image = docker.build('frontend.blazor.bootstrap', '-f  ./src/Frontend.Blazor.Bootstrap.Dockerfile .')
                }
            }
        }
        stage('Push image') {
            steps{
                script{
                    docker.withRegistry("https://docker.lenmahaffey.com", "dockerLogin") {
                        image.push('latest')
                        image.push(now.format("yyyy-MM-dd"))
                    }
                }
            }
        } 
    }
}
