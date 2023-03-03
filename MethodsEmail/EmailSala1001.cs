using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MethodsEmail
{
    public class EmailSala1001
    {
        /// <summary>
        ///     Constructor inicia atributos com valores default.
        /// </summary>
        public EmailSala1001()
        {
            EnderecoOrigem = "contato@sala1001.com.br";
            SenhaEnderecoOrigem = "sl1001@857";
            NomeEnderecoOrigem = "Sala 1001";
            Host = "mail.methodsinformatica.com.br";
            Port = 26;
            _enderecosDestino = new List<string>();
            _diretoriosAnexos = new List<string>();
        }

        /// <summary>
        ///     Diretórios completos de todos os anexos que devem ser enviados.
        /// </summary>
        private readonly List<string> _diretoriosAnexos;

        /// <summary>
        ///     Endereços para os quais este email será enviado.
        /// </summary>
        private readonly List<string> _enderecosDestino;

        /// <summary>
        ///     Corpo do email.
        /// </summary>
        private string _corpo;

        /// <summary>
        ///     Endereço que enviará o email.
        /// </summary>
        public string EnderecoOrigem { private get; set; }

        /// <summary>
        ///     Nome do endereço que enviará o email.
        /// </summary>
        public string NomeEnderecoOrigem { private get; set; }

        /// <summary>
        ///     Senha do endereço que enviará o email.
        /// </summary>
        public string SenhaEnderecoOrigem { private get; set; }

        /// <summary>
        ///     Assunto do email.
        /// </summary>
        public string Assunto { private get; set; }

        /// <summary>
        ///     Host do endereço que enviará o email.
        /// </summary>
        public string Host { private get; set; }

        /// <summary>
        ///     Porta utilizada pelo endereço que enviará o email.
        /// </summary>
        public int Port { private get; set; }

        /// <summary>
        ///     Sobrescreve caracteres especiais para html.
        /// </summary>
        public string Corpo
        {
            private get { return _corpo; }
            set { _corpo = value.Replace("\r\n", "<br />").Replace("\r", "").Replace("\n", "<br />"); }
        }

        /// <summary>
        ///     Adiciona um novo endereço na lista de destinatários.
        /// </summary>
        /// <param name="endereco">Endereço de email que deve ser adicionado.</param>
        public void AdicionarEnderecoDestino(string endereco)
        {
            _enderecosDestino.Add(endereco);
        }

        /// <summary>
        ///     Adiciona um novo diretório completo que contém um anexo.
        /// </summary>
        /// <param name="diretorio">Diretório completo.</param>
        public void AdicionarDiretorioAnexo(string diretorio)
        {
            _diretoriosAnexos.Add(diretorio);
        }

        /// <summary>
        ///     Envia email para todos os destinatários da lista.
        /// </summary>
        public void Enviar()
        {
            foreach (MailMessage email in _enderecosDestino.Select(CriarEmail))
            {
                AdicionarAnexos(email);
                SmtpClient client = CriarSmtpClient();
                client.Send(email);
            }
        }

        /// <summary>
        ///     Cria email.
        /// </summary>
        /// <param name="endereco">Endereço do destinatário.</param>
        /// <returns><see cref="MailMessage" />.</returns>
        private MailMessage CriarEmail(string endereco)
        {
            var email = new MailMessage();
            email.To.Add(endereco);
            email.From = new MailAddress(EnderecoOrigem, NomeEnderecoOrigem, Encoding.UTF8);
            email.Subject = Assunto;
            email.SubjectEncoding = Encoding.UTF8;
            email.Body = Corpo;
            email.BodyEncoding = Encoding.UTF8;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            return email;
        }

        /// <summary>
        ///     Adiciona anexos ao email.
        /// </summary>
        /// <param name="email"><see cref="MailMessage" /> que deve receber os anexos.</param>
        private void AdicionarAnexos(MailMessage email)
        {
            foreach (string diretorio in _diretoriosAnexos)
            {
                email.Attachments.Add(new Attachment(diretorio));
            }
        }

        /// <summary>
        ///     Cria cliente smtp.
        /// </summary>
        /// <returns><see cref="SmtpClient" />.</returns>
        private SmtpClient CriarSmtpClient()
        {
            return new SmtpClient { Credentials = new NetworkCredential(EnderecoOrigem, SenhaEnderecoOrigem), Port = Port, Host = Host };
        }
    }
}