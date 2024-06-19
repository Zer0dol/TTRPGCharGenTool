using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace TTRPG_Tool.classes
{
    internal class LanguageFilesParser
    {
        public static void GetLangOptionsToCombobox(ComboBox comboBox)
        {
            string lang_folder = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\lang";
            comboBox.Items.Clear();

            DataSet dataset = new DataSet();
            DataTable datatable = new DataTable("Languages");
            DataColumn datacolumn;
            DataRow datarow;

            datacolumn = new DataColumn();
            datacolumn.DataType = typeof(string);
            datacolumn.ColumnName = "Languagecode";
            datatable.Columns.Add(datacolumn);

            datacolumn = new DataColumn();
            datacolumn.DataType = typeof(string);
            datacolumn.ColumnName = "Languagename";
            datatable.Columns.Add(datacolumn);
            dataset.Tables.Add(datatable);
            try
            {
                foreach (var file in Directory.GetFiles(lang_folder, "*.json", SearchOption.TopDirectoryOnly))
                {
                    string readJsonFile = File.ReadAllText(file);
                    LanguageClass lang_converted = JsonConvert.DeserializeObject<LanguageClass>(readJsonFile);
                    datarow = datatable.NewRow();
                    datarow["Languagecode"] = lang_converted.Languagecode;
                    datarow["Languagename"] = lang_converted.Languagename;
                    datatable.Rows.Add(datarow);
                }
            }
            catch { }
            comboBox.ItemsSource = dataset.Tables[0].DefaultView;
            comboBox.DisplayMemberPath = "Languagename";
            comboBox.SelectedValuePath = "Languagecode";
        }
        public static void SetCurrentSettings()
        {
            string lang_folder = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\lang\\";
            string settings_file = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\settings.json";
            string language_code;
            DirectoryInfo lang_directory = new DirectoryInfo(lang_folder);
            try
            {
                string read_settings_file = File.ReadAllText(settings_file);
                Settings settings = JsonConvert.DeserializeObject<Settings>(read_settings_file);
                language_code = settings.Language;
                FileInfo[] lang_file = lang_directory.GetFiles("*" + language_code + ".json");
                foreach (FileInfo file in lang_file)
                {
                    string current_lang_file = file.FullName;
                    string read_lang_file = File.ReadAllText(current_lang_file);
                    LanguageClass lang_converted = JsonConvert.DeserializeObject<LanguageClass>(read_lang_file);

                    UILangStrings.UIReturnHome = lang_converted.UIReturnHome;
                    UILangStrings.UIMenuPage = lang_converted.UIMenuPage;
                    UILangStrings.UIYes = lang_converted.UIYes;
                    UILangStrings.UINo = lang_converted.UINo;
                    UILangStrings.UIMinimizeButton = lang_converted.UIMinimizeButton;
                    UILangStrings.UIRestoreDown = lang_converted.UIRestoreDown;
                    UILangStrings.UIMaximize = lang_converted.UIMaximize;
                    UILangStrings.UICloseWindow = lang_converted.UICloseWindow;
                    UILangStrings.UINewTab = lang_converted.UINewTab;
                    UILangStrings.UITextClosingConfirmationTitle = lang_converted.UITextClosingConfirmationTitle;
                    UILangStrings.UITextClosingConfirmationPrompt = lang_converted.UITextClosingConfirmationPrompt;
                    UILangStrings.UISettingsButton = lang_converted.UISettingsButton;
                    UILangStrings.UISettingsApplyLangButton = lang_converted.UISettingsApplyLangButton;
                    UILangStrings.UISettingsLanguage = lang_converted.UISettingsLanguage;
                    UILangStrings.UISettingsLanguageDesc = lang_converted.UISettingsLanguageDesc;
                    UILangStrings.UISettingsApp = lang_converted.UISettingsApp;
                    UILangStrings.UISettingsCurrentVersion = lang_converted.UISettingsCurrentVersion;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }
        }
        public static string GetLanguageCode()
        {
            string lang_folder = Convert.ToString(System.AppDomain.CurrentDomain.BaseDirectory) + "\\lang";
            string langage_code = "";
            try
            {
                foreach (var file in Directory.GetFiles(lang_folder, "*.json", SearchOption.TopDirectoryOnly))
                {
                    string readJsonFile = File.ReadAllText(file);
                    LanguageClass lang_converted = JsonConvert.DeserializeObject<LanguageClass>(readJsonFile);
                    langage_code = lang_converted.Languagecode;
                }
            }
            catch { }
            return langage_code;
        }
    }
}
