pipeline{
    agent any
    
    triggers{
        pollSCM('*/15 * * * *')
    }
                
    stages{
        stage("Build project") {
            parallel {
            stage("Build API"){
                steps{
                    sh "dotnet build lego-collectors.sln"
                }
            }

             stage('Build Frontend') {
                 steps {
                     dir('LegoCollectors.WebAPI/ClientApp'){
                        sh "npm install"
                        sh "npm run build"
                        }
                    }
                }
            }

        }
    }
    post {
        always {
            discordSend description: 'Jenkins Pipeline Build', footer: 'Footer Text', link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/951803826078384128/7cvhsiIuAsft99lnjxOu_xQJIT8M3TpAI01HV6iKcAZS18ghfe9TVv8W5SRaIbCGQbiY'
        }
    }
  
}
