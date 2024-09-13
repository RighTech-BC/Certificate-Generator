using Browsers;
using ProcessManager;
using System;
using System.Windows.Forms;

namespace CertificateCreator
{
    public partial class CC : Form
    {
        public CC()
        {
            InitializeComponent();

            Openssl.InstallationCheckup(lbl_Openssl_Status, tlp_Body);
        }

        private void Browse(object sender, EventArgs e) => OFD.Get(sender);
        private void BrowseSave(object sender, EventArgs e) => SFD.Get(sender);


        private void btn_Key_Generate_Click(object sender, EventArgs e) =>
            Openssl.Create($"genrsa -out \"{txt_Key_Path.Text}\" {cmb_Key_Size.Text}", gp_Key);

        private void btn_CSR_Generate_Click(object sender, EventArgs e)
        {
            string Country = txt_CSR_CountryCode.Text ?? string.Empty;
            string State = txt_CSR_State.Text ?? string.Empty;
            string City = txt_CSR_City.Text ?? string.Empty;
            string Email = txt_CSR_Email.Text ?? string.Empty;
            string Organization = txt_CSR_OrganizationName.Text ?? string.Empty;
            string OrganizationUnit = txt_CSR_OrganizationUnitName.Text ?? string.Empty;
            string CommonName = txt_CSR_CommonName.Text ?? string.Empty;

            Openssl.Create($"req -new -key \"{txt_CSR_KeyPath.Text}\" -out \"{txt_CSR_Path.Text}\" -subj \"/C={Country}/ST={State}/L={City}/O={Organization}/OU={OrganizationUnit}/CN={CommonName}/emailAddress={Email}\"", gp_CSR);
        }

        private void btn_X509_Generate_Click(object sender, EventArgs e) =>
            Openssl.Create($"x509 -req -days {txt_X509_Days.Text} -in \"{txt_X509_CSRPath.Text}\" -signkey \"{txt_X509_KeyPath.Text}\" -out \"{txt_X509_Path.Text}\"", gp_X509);

        private void btn_X509CA_Generate_Click(object sender, EventArgs e) =>
            Openssl.Create($"x509 -req -in \"{txt_X509CA_CSRPath.Text}\" -CA \"{txt_X509CA_CACRTPath.Text}\" -CAkey \"{txt_X509CA_CAKeyPath.Text}\" -CAcreateserial -out \"{txt_X509CA_Path.Text}\" -days {txt_X509CA_Days.Text}", gp_X509CA);

        private void txt_PKCS12_Generate_Click(object sender, EventArgs e) =>
            Openssl.Create($"pkcs12 -export -out \"{txt_PKCS12_Path.Text}\" -inkey \"{txt_PKCS12_KeyPath.Text}\" -in \"{txt_PKCS12_CRTPath.Text}\" -passout pass:{txt_PKCS12_Password.Text}", gp_PKCS12);


    }
}
