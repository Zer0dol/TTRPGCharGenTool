using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TTRPG_Tool.classes;

namespace TTRPG_Tool.dialogs
{
    /// <summary>
    /// Логика взаимодействия для SettingsDialog.xaml
    /// </summary>
    public partial class SettingsDialog : Window
    {
        public SettingsDialog()
        {
            InitializeComponent();
            LanguageFilesParser.GetLangOptionsToCombobox(LanguageCombobox);
            GetSettingsFromFile();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void GetSettingsFromFile()
        {
            string settings_file = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\settings.json";
            try
            {
                string read_settings_file = File.ReadAllText(settings_file);
                Settings settings = JsonConvert.DeserializeObject<Settings>(read_settings_file);
                LanguageCombobox.SelectedValue = settings.Language;
                
            }
            catch { }
        }
        private void SetNewLangSetting(object sender, EventArgs e)
        {
            RelaunchButton.Visibility = Visibility.Visible;
        }
        private void RelaunchApp(object sender, RoutedEventArgs e)
        {
            string settings_file = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\settings.json";
            try
            {
                string new_lang_code = LanguageCombobox.SelectedValue.ToString();
                string read_settings_file = File.ReadAllText(settings_file);
                dynamic SettingsJson = JsonConvert.DeserializeObject(read_settings_file);
                SettingsJson["Language"] = new_lang_code;
                string outputSettings = JsonConvert.SerializeObject(SettingsJson, Formatting.Indented);
                File.WriteAllText(settings_file, outputSettings);
            }
            catch { }
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
