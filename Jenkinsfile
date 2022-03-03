pipeline{
    agent any
    
    tools {nodejs "node"}
    
    triggers{
        pollSCM("5 * * * *")
    }
    stages{
        stage("Build"){
            steps{
                sh "dotnet build lego-collectors.sln"
            }
        }
         stage('Tests') {
            steps {
            dir('LegoCollectors.WebAPI/ClientApp') {
            sh 'npm build'
        }
      }
    }
    }
}
