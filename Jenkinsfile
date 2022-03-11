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
                    sh "dotnet test --collect:'XPlat Code Coverage'"
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
            discordSend description: 'Jenkins Pipeline Build', footer: 'Footer Text', link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/951807737933754438/B_6dDbYocvQJBwQYqdZdPhxvUIWXADzCdAiPZTOvu5ytnXwyKiFICFX3fqQxWP0EHRYP'
            step([$class: 'CoberturaPublisher', autoUpdateHealth: false, autoUpdateStability: false, coberturaReportFile: '***/coverage.cobertura.xml', failUnhealthy: false, failUnstable: false, maxNumberOfBuilds: 0, onlyStable: false, sourceEncoding: 'ASCII', zoomCoverageChart: false])
        }
    }
  
}
