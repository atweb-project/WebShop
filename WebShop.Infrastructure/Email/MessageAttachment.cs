using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Infrastructure.Email
{
    public class MessageAttachment
    {
        private readonly String mediaType;
        private readonly Stream stream;
        public String FileName { get; set; }

        public MessageAttachment(String mediaType, String fileName)
        {
            this.mediaType = mediaType;

            if (fileName == null)
                throw new ArgumentNullException("fileName");

            var info = new FileInfo(fileName);

            if (!info.Exists)
                throw new ArgumentException("The specified file does not exists", "fileName");

            this.FileName = fileName;
        }

        public MessageAttachment(string fileName, string mediaType, Stream stream)
            : this(mediaType, stream)
        {
            this.FileName = fileName;
        }


        public MessageAttachment(String mediaType, Stream stream)
        {
            this.mediaType = mediaType;

            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
        }

        public String MediaType
        {
            get { return mediaType; }
        }

        public Stream Stream
        {
            get { return stream; }
        }


    }
}
