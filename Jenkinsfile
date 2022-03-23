pipeline{
    agent any
    
    triggers{
        pollSCM('*/15 * * * *')
    }
                
    stages{
        stage("Build project") {
            parallel {
                stage("Build API"){
                    when {
                        anyOf {
                            changeset "API/**"
                            changeset "BLL/**"
                            changeset "DAL/**"
                        }
                    }
                    steps{
                        sh "dotnet build --configuration Release"
                        sh "docker-compose build api"
                    }
                }

                stage('Build Frontend') {
                    when {
                        changeset "Web/**"
                    }
                    steps {
                     sh "docker-compose build web"
                    }
                }
            }

        }
        stage("Unit test"){
            steps{
                sh "dotnet test --collect:'XPlat Code Coverage'"
            }
        }
        stage("Clean containers") {
            steps {
                script {
                    try {
                        sh "docker-compose down"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose up -d"
            }
        }
    }
    post {
        always {
            discordSend description: 'Jenkins Pipeline Build', footer: 'Footer Text', link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL: 'https://discord.com/api/webhooks/951807737933754438/B_6dDbYocvQJBwQYqdZdPhxvUIWXADzCdAiPZTOvu5ytnXwyKiFICFX3fqQxWP0EHRYP'
            step([$class: 'CoberturaPublisher', autoUpdateHealth: false, autoUpdateStability: false, coberturaReportFile: '**/coverage.cobertura.xml', failUnhealthy: false, failUnstable: false, maxNumberOfBuilds: 0, onlyStable: false, sourceEncoding: 'ASCII', zoomCoverageChart: false])
        }
    }
  
}
