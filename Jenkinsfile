pipeline{
    agent any
    
    tools {nodejs "node"}
    
    triggers{
        pollSCM('*/15 * * * *')
    }
                
    stages{
        stage("Build"){
            steps{
                sh "dotnet build lego-collectors.sln"
                sh "npm install --prefix ./LegoCollectors.WebAPI/ClientApp"
            }
        }
        
         stage('Tests') {
             steps {
                sh "npm install"
                sh "npm build"
                }
            }
       
    }
  
}
