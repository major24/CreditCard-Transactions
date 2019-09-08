node {
	stage ('Checkout git repo') {
		git branch: 'master', url: 'https://github.com/major24/creditcard-transactions.git'
	}
	stage('Restore Packages') {
  		bat "dotnet restore"
	}
	stage('Clean project') {
		bat "dotnet clean"
	}
	stage('Build project') {
		bat "dotnet build"
	}
	stage('Publish project') {
		bat "dotnet publish -c Production -o publish"
	}
}
