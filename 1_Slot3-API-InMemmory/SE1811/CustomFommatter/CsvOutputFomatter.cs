using System.Text;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc.Formatters;
using SE1811.model;

namespace SE1811.CustomFommatter
{
    public class CsvOutputFomatter : TextOutputFormatter
    {
        public CsvOutputFomatter()
        {
            // Định nghĩa các media type được hỗ trợ
            SupportedMediaTypes.Add("text/csv");

            // Định nghĩa các encoding được hỗ trợ
            SupportedEncodings.Add(Encoding.UTF8);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {

            // Lấy response từ context
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            // Gọi phương thức FormatCsv để tạo nội dung CSV
            FormatCsv(buffer, context.Object);
            // Ghi dữ liệu vào response
            await response.WriteAsync(buffer.ToString(), selectedEncoding);

        }

        private static void FormatCsv(StringBuilder buffer, object obj) {
            // Thêm tiêu đề CSV

            buffer.AppendLine("Id,Name,Price");
            if (obj is IEnumerable<Product> products)
            {
                foreach (var product in products)
                {
                    buffer.AppendLine($"{product.ProductID},{product.NameProduct},{product.Price}");
                }
            }
            else if (obj is Product product)
            {
                buffer.AppendLine($"{product.ProductID},{product.NameProduct},{product.Price}");
            }
        }


        protected override bool CanWriteType(Type? type)
        {
            return typeof(Product).IsAssignableFrom(type) || typeof(IEnumerable<Product>).IsAssignableFrom(type);
        }
    }
}
