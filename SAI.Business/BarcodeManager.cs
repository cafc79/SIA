using System;
using System.Drawing;
using System.IO;
using GenCode128;
using ThoughtWorks.QRCode.Codec;

namespace DS.SAI.Business
{
    public class BarcodeManager
    {
        public Image QREncode(string txtEncodeData, string errorCorrect)
        {
            if (!string.IsNullOrEmpty(txtEncodeData.Trim()))
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                /*
                if (encoding == "Byte") qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                else if (encoding == "AlphaNumeric")*/
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;
                try
                {
                    qrCodeEncoder.QRCodeScale = 3;
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid size!");
                }
                try
                {
                    qrCodeEncoder.QRCodeVersion = 5;
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid version !");
                }

                if (errorCorrect == "L")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                else if (errorCorrect == "M")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                else if (errorCorrect == "Q")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                else if (errorCorrect == "H")
                    qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

                Image image;
                image = qrCodeEncoder.Encode(txtEncodeData);
                return image;
            }
            return null;
        }

        public Image Barcode128(string txtEncodeData, int tamaño)
        {
            try
            {
                return Code128Rendering.MakeBarcodeImage(txtEncodeData, tamaño, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

    }
}
