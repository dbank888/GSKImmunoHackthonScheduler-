using Gsk.Hack.Schedule.API.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gsk.Hack.Schedule.API.Controllers
{
    [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        private String API_KEY = "u1QejECuToaPofZueT0ntA";
        //secret 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
        [HttpPost]
        [Route("send")]
        public async Task<IHttpActionResult> SendEmail(EmailRequest request)
        {
            try
            {
                var msg = new SendGridMessage();

                msg.SetFrom(new EmailAddress("patrick.alburtus@snrblabs.com", "Pat Alburtus"));

                var recipients = new List<EmailAddress>
                {
                    new EmailAddress(request.RecipientEmailAddress, request.RecipientName)
                };

                msg.AddTos(recipients);

                msg.SetSubject(request.Subject);

                msg.AddContent(MimeType.Text, request.Body);

                var client = new SendGridClient(API_KEY);
                var respone = await client.SendEmailAsync(msg);

                return Ok(respone.StatusCode + ": " + respone.Body);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

       
    }
}
