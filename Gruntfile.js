module.exports = function(grunt) {

    grunt.loadNpmTasks('grunt-msbuild');
    grunt.loadNpmTasks('grunt-nunit-runner');
    grunt.loadNpmTasks('grunt-nuget-install');
    grunt.loadNpmTasks('grunt-exec');
    grunt.loadNpmTasks('grunt-wait');

    //
    // 'Build' task builds the solution and runs unit tests
    //
    grunt.registerTask('build', ['exec:update_nuget',
        'exec:restore_nuget',
        'msbuild',
        'exec:nunit_unittests'
    ]);

    //
    // 'Build-full' task builds the solution, starts event store and runs unit and integration tests
    //
    grunt.registerTask('build-full', ['exec:update_nuget',
        'exec:restore_nuget',
        'msbuild',
        'exec:start_eventstore',
        'wait',
        'exec:nunit_unittests',
        'exec:nunit_integrationtests'
    ]);

    //
    //  'Es' task starts the event store
    //
    grunt.registerTask('es', ['exec:start_eventstore']);

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
        exec: {
            start_eventstore: "start Thirdparty\\EventStore\\EventStore.SingleNode.exe",
            update_nuget: "Thirdparty\\NuGet\\nuget.exe update -self",
            restore_nuget: "Thirdparty\\NuGet\\nuget.exe restore Source\\SponsorPortal.sln",
            nunit_unittests: "Source\\packages\\NUnit.Runners.2.6.3\\tools\\nunit-console.exe Source\\SponsorPortal.Tests.Unit\\SponsorPortal.Tests.Unit.csproj /include:UnitTests",
            nunit_integrationtests: "Source\\packages\\NUnit.Runners.2.6.3\\tools\\nunit-console.exe Source\\SponsorPortal.Tests.Integration\\SponsorPortal.Tests.Integration.csproj /include:IntegrationTests"
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