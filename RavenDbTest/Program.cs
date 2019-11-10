using System.Threading.Tasks;

using Raven.Client.ServerWide;
using Raven.Embedded;

namespace RavenDbTest {
	internal class Program {
		private static async Task Main(string[] args) {
			var so = new ServerOptions {
				DataDirectory = "RavenData"
			};
			EmbeddedServer.Instance.StartServer(so);
			var dbo = new DatabaseOptions(
				new DatabaseRecord { DatabaseName = "Embedded" }
			);
			using var store = await EmbeddedServer.Instance.GetDocumentStoreAsync(dbo);
			using var session = store.OpenSession();

			var url = await EmbeddedServer.Instance.GetServerUriAsync();

			EmbeddedServer.Instance.OpenStudioInBrowser();
		}
	}
}
