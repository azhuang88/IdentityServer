using System.Web;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class ClientCertificateInputModel : CertificateInputModel
    {
        public HttpPostedFileBase Thumbprintfile { get; set; }
        public override HttpPostedFileBase File
        {
            get { return Thumbprintfile; }
        }
        public override string Name
        {
            get { return "Thumbprintfile"; }
        }
    }
}