using System;
using System.IO;
using System.Windows.Forms;
class Program {
static void Main() {
if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "extracted.zip")) {
try {
File.Delete(AppDomain.CurrentDomain.BaseDirectory + "extracted.zip");
System.Diagnostics.Process.Start("subst", "/D Z:");
} catch {
MessageBox.Show("Something went wrong", "QR-ROM Unmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
try {
Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "extracted", true);
} catch {
MessageBox.Show("Close any programs using the QR-ROM disk, then try again.", "QR-ROM Unmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
} else {
MessageBox.Show("The QR-ROM drive is empty", "QR-ROM Unmount", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
}
}