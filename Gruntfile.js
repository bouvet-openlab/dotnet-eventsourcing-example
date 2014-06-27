module.exports = function(grunt) {

    grunt.loadNpmTasks('grunt-msbuild');
    grunt.loadNpmTasks('grunt-nunit-runner');
    grunt.loadNpmTasks('grunt-nuget-install');
    grunt.loadNpmTasks('grunt-exec');
    grunt.loadNpmTasks('grunt-wait');

    grunt.registerTask('build', ['nuget_install', 'msbuild', 'exec', 'wait', 'nunit']);
    grunt.registerTask('es', ['exec']); //Starts EventStore

    grunt.initConfig({
        msbuild: {
            dev: {
                src: ['Source\\SponsorPortal.sln'],
                options: {
                    projectConfiguration: 'Release',
                    targets: ['Clean', 'Rebuild'],
                    stdout: true,
                    version: 4.0,
                    maxCpuCount: 4,
                    buildParameters: {
                        WarningLevel: 2
                    },
                    verbosity: 'normal'
                }
            }
        },
        nunit: {
            options: {
                files: [
                    'Source\\Tests\\Integration\\SponsorPortal.ApplicationForm.Tests.Integration\\SponsorPortal.ApplicationForm.Tests.Integration.csproj',
                    'Source\\Tests\\Unit\\SponsorPortal.ApplicationForm.Common.Tests\\SponsorPortal.ApplicationForm.Common.Tests.csproj',
                    'Source\\Tests\\Unit\\SponsorPortal.ApplicationForm.Query.Tests\\SponsorPortal.ApplicationForm.Query.Tests.csproj',
                    'Source\\Tests\\Unit\\SponsorPortal.ApplicationForm.Tests.Unit\\SponsorPortal.ApplicationForm.Tests.Unit.csproj',
                    'Source\\Tests\\Unit\\SponsorPortal.CommandApi.Tests.Unit\\SponsorPortal.CommandApi.Tests.Unit.csproj',
                ],
                path: 'Source\\packages\\NUnit.Runners.2.6.3\\tools'
            }
        },
        nuget_install: {
            file: 'Source\\SponsorPortal.sln',
        },
        exec: {
            start_eventstore: "start Thirdparty\\EventStore\\EventStore.SingleNode.exe"
        },
        wait: {
            options: {
                delay: 5000
            },
            pause: {
                options: {
                    before: function(options) {
                        console.log('pausing %dms to allow EventStore to start up before executing integration tests', options.delay);
                    },
                    after: function() {
                        console.log('pause end');
                    }
                }
            }
        }
    });
};