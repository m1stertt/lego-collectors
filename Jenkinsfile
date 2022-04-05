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
                            changeset "LegoCollectors.Core/**"
                            changeset "LegoCollectors.DataAccess/**"
                            changeset "LegoCollectors.Domain/**"
                            changeset "LegoCollectors.Security/**"
                            changeset "LegoCollectors.WebApi/**"
                            changeset "LegoCollectors.DataAccess.Test/**"
                        }
                    }
                    steps{
                        sh "dotnet build --configuration Release"
                        sh "docker-compose --env-file config/Test.env build api"
                    }
                }

                stage('Build Frontend') {
                    when {
                        changeset "Vue/**"
                    }
                    steps {
                        sh "docker-compose --env-file config/Test.env build web"
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
                        sh "docker-compose --env-file config/Test.env down"
                    }
                    finally { }
                }
            }
        }
        stage("Deploy") {
            steps {
                sh "docker-compose --env-file config/Test.env up -d"
            }
        }

        stage("Push to registry") {
            steps {
                sh "docker-compose --env-file config/Test.env push"
            }
        }
    }
    post {
        always {
            discordSend description: 'Jenkins Pipeline Build', footer: 'Footer Text', link: env.BUILD_URL, result: currentBuild.currentResult, unstable: false, title: JOB_NAME, webhookURL:env.DISCORD_WEBHOOK
            step([$class: 'CoberturaPublisher', autoUpdateHealth: false, autoUpdateStability: false, coberturaReportFile: '**/coverage.cobertura.xml', failUnhealthy: false, failUnstable: false, maxNumberOfBuilds: 0, onlyStable: false, sourceEncoding: 'ASCII', zoomCoverageChart: false])
        }
    }
  
}
