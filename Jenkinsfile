pipeline{
    agent any
    trigger{
        pollSCM("*/5 * * * *")
    }
    stages{
        stage("Build"){
            step{
                sh "dotnet build lego-collectors.sln"
            }
        }
    }
}
