pipeline{
    agent any
    
    tools {nodejs "node"}
    
    triggers{
        pollSCM(*/15 * * * *)
    }
    stages{
        stage("Build"){
            steps{
                sh 'echo "message---------------------------------"'
                sh "dotnet build lego-collectors.sln"
            }
        }
         stage('Tests') {
            steps {
            sh 'echo "message--------------------------------------"'
            dir('LegoCollectors.WebAPI/ClientApp') {
            sh 'npm build'
        }
      }
    }
    }
}
