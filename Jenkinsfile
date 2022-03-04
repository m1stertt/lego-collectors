pipeline{
    agent any
    
    tools {nodejs "node"}
    
    triggers{
        pollSCM(*/15 * * * *)
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
                    sh "npm install"
                    sh "npm build"
    }
        }
    }
}
