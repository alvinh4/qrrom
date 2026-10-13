using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
class Program {
static void Main() {
if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "extracted")) {
var process = new Process();
process.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "zbarcam.exe";
process.StartInfo.Arguments = "--oneshot";
process.StartInfo.UseShellExecute = false;
process.StartInfo.RedirectStandardOutput = true;
process.StartInfo.CreateNoWindow = true;

process.Start();

string output = process.StandardOutput.ReadToEnd();

process.WaitForExit();
if (output.Contains("QR-Code:")) {
var data = output.Replace("QR-Code:", "");
if (data.Contains("iso:")) {
var b64 = data.Replace("iso:", "");
try {
byte[] zipBytes = Convert.FromBase64String(b64);

File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "extracted.zip", zipBytes);
System.Threading.Thread.Sleep(1000);
var ptwo = new Process();

ptwo.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "7z.exe";
ptwo.StartInfo.Arguments = "x \"" + AppDomain.CurrentDomain.BaseDirectory + "extracted.zip\" -o\"" + AppDomain.CurrentDomain.BaseDirectory + "extracted\" -y";
ptwo.StartInfo.UseShellExecute = false;
ptwo.StartInfo.CreateNoWindow = true;

ptwo.Start();
ptwo.WaitForExit();
if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "extracted")) {
MessageBox.Show("Unable to extract.", "QR-ROM Scanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
} else {
Process.Start("subst", "Z: " + AppDomain.CurrentDomain.BaseDirectory + "extracted");
}
} catch {
MessageBox.Show("Invalid Base64.", "QR-ROM Scanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
} else {
MessageBox.Show("The scanned QR Code is not supported.", "QR-ROM Scanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
} else {
MessageBox.Show("The scanned barcode is not a QR Code.", "QR-ROM Scanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
} else {
MessageBox.Show("A QR-ROM is already inserted.\n\nUse the 'Eject' function to remove it.", "QR-ROM Scanner", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}