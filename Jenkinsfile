node {
	stage ('Checkout git repo') {
		git branch: 'master', url: 'https://github.com/major24/creditcard-transactions.git'
	}
	stage('Restore Packages') {
 		steps {
  			bat "dotnet restore"
 		}
	}
}
