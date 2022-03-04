pipeline{
    agent any
    
    triggers{
        pollSCM('*/15 * * * *')
    }
                
    stages{
        stage("Build API"){
            steps{
                sh "dotnet build lego-collectors.sln"
            }
        }
        
         stage('Build Frontend') {
             steps {
                 dir('/LegoCollectors.WebAPI/ClientApp'){
                    sh "npm install"
                    sh "npm run build"
                    }
                }
            }
       
    }
  
}
