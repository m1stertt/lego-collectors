pipeline{
    agent any
    triggers{
        pollSCM("5 * * * *")
    }
    stages{
        stage("Build"){
            steps{
                sh "dotnet build lego-collectors.sln"
            }
        }
    }
}
