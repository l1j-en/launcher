using Launcher.Models;
using Launcher.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Polymorphs : Form
    {
        private static Dictionary<string, string> polyList = new Dictionary<string, string>
        {
            {"Gandi Orc","gandi orc"},
            {"Assassin","assassin"},
            {"Assassin Master 52","assassin 52"},
            {"Assassin Master 55","assassin 55"},
            {"Assassin Master 60","assassin 60"},
            {"Assassin Master 65","assassin 65"},
            {"Assassin Master 70","assassin 70"},
            {"Atuba Orc","atuba orc"},
            {"Bandit","bandit bow morph"},
            {"Baphomet","baphomet"},
            {"Varlok 52","barlog 52"},
            {"Varlok 55","barlog 55"},
            {"Varlok 60","barlog 60"},
            {"Varlok 65","barlog 65"},
            {"Varlok 70","barlog 70"},
            {"Beleth","beleth"},
            {"Kurtz","black knight chief morph"},
            {"Black Knight","black knight morph"},
            {"Orc Archer","bow orc"},
            {"Bugbear","bugbear"},
            {"Cerberus","cerberus"},
            {"Cockatrice","cockatrice"},
            {"Cyclops","cyclops"},
            {"Dark Elder","dark elder"},
            {"Dark Elf 52","darkelf 52"},
            {"Dark Elf 55","darkelf 55"},
            {"Dark Elf 60","darkelf 60"},
            {"Dark Elf 65","darkelf 65"},
            {"Dark Elf 70","darkelf 70"},
            {"Dark Elf Carrier","darkelf carrier"},
            {"Dark Elf Guard (Bow)","darkelf guard morph"},
            {"Dark Elf Ranger","darkelf ranger morph"},
            {"Dark Elf Guard (Spear)","darkelf spear morph"},
            {"Dark Elf Wizard","darkelf wizard morph"},
            {"Death Knight 52","death 52"},
            {"Death Knight 55","death 55"},
            {"Death Knight 60","death 60"},
            {"Death Knight 65","death 65"},
            {"Death Knight 70","death 70"},
            {"Deer","deer"},
            {"Demon","demon"},
            {"Dudamara Orc","dudamara orc"},
            {"Dwarf","dwarf"},
            {"Elder","elder"},
            {"Undead Elmore General","elmor general morph"},
            {"Undead Elmore Soldier","elmor soldier morph"},
            {"Ettin","ettin"},
            {"Fire Archer","fire bowman morph"},
            {"Floating Eye","floating eye"},
            {"Gelatinous Cube","gelatincube"},
            {"Dark Elf General 52","general 52"},
            {"Dark Elf General 55","general 55"},
            {"Dark Elf General 60","general 60"},
            {"Dark Elf General 65","general 65"},
            {"Dark Elf General 70","general 70"},
            {"Ghast","ghast"},
            {"Ghoul","ghoul"},
            {"Giant","giant a morph"},
            {"Giant Ant","giant ant"},
            {"Giant Soldier Ant","giant ant soldier"},
            {"Goblin","goblin"},
            {"Greater Minotaur","great minotaur morph"},
            {"Griffin","griffon"},
            {"Guardian Armor","guardian armor morph"},
            {"Jack-o-Lantern","jack o lantern"},
            {"King Bugbear","king bugbear"},
            {"Kobold","kobolds"},
            {"Lesser Demon","lesser demon"},
            {"Lycanthrope","lycanthrope"},
            {"Middle Oum","middle oum"},
            {"Killer Rabbit","mighty rich crazy rabbit"},
            {"Milk Cow","milkcow"},
            {"Minotaur","minotaur i morph"},
            {"Baltuzar","necromancer1"},
            {"Caspa","necromancer2"},
            {"Merkyor","necromancer3"},
            {"Sema","necromancer4"},
            {"Dark Shadow","neo black assassin"},
            {"Dark Knight","neo black knight"},
            {"Dark Magister","neo black mage"},
            {"Dark Ranger","neo black scouter"},
            {"Shadow Master","neo gold assassin"},
            {"Sword Master","neo gold knight"},
            {"Wizardry Master","neo gold mage"},
            {"Arrow Master","neo gold scouter"},
            {"Arch Shadow","neo platinum assassin"},
            {"Arch Knight","neo platinum knight"},
            {"Arch Wizard","neo platinum mage"},
            {"Arch Scout","neo platinum scouter"},
            {"Silver Shadow","neo silver assassin"},
            {"Silver Knight","neo silver knight"},
            {"Silver Magister","neo silver mage"},
            {"Silver Ranger","neo silver scouter"},
            {"Neruga Orc","neruga orc"},
            {"Ogre","ogre"},
            {"Orc","orc"},
            {"Orc Fighter","orc fighter"},
            {"Orc Scout","orc scout polymorph"},
            {"Rova Orc","rova orc"},
            {"Scorpion","scorpion"},
            {"Arachnevil","shelob"},
            {"Skeleton Archer","skeleton archer polymorph"},
            {"Skeleton Axeman","skeleton axeman polymorph"},
            {"Skeleton Pikeman","skeleton pike polymorph"},
            {"Skeleton","skeleton polymorph"},
            {"Spartoi","spartoi polymorph"},
            {"Lance Master 52","spearm 52"},
            {"Lance Master 55","spearm 55"},
            {"Lance Master 60","spearm 60"},
            {"Lance Master 65","spearm 65"},
            {"Lance Master 70","spearm 70"},
            {"Stone Golem","stone golem"},
            {"Succubus","succubus morph"},
            {"Troll","troll"},
            {"Arachnevil Elder","ungoliant"},
            {"Werewolf","werewolf"},
            {"Wild Boar","wild boar"},
            {"Yeti","yeti morph"},
            {"Zombie","zombie"}
        };

        private List<string> _availablePolymorphs = new List<string>();
        private List<string> _selectedPolymorphs = new List<string>();

        private LauncherConfig _config;

        public Polymorphs(LauncherConfig config)
        {
            this._config = config;
            InitializeComponent();

            this.btn_update.DialogResult = DialogResult.OK;
            this.lst_selected.DrawMode = DrawMode.OwnerDrawFixed;
            this.lst_selected.DrawItem += lst_selected_DrawItem;
        }
        
        private void lst_selected_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            var fontStyle = FontStyle.Regular;
            if(!polyList.Keys.Contains(lst_selected.Items[e.Index].ToString()))
            {
                fontStyle = FontStyle.Bold;
            }
            
            e.Graphics.DrawString(lst_selected.Items[e.Index].ToString(), new Font("Microsoft Sans Serif", 8.25f, fontStyle), Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Polymorphs_Load(object sender, EventArgs e)
        {
            foreach (var poly in polyList)
            {
                this._availablePolymorphs.Add(poly.Key);
            }

            var currentPolies = ReadCurrentPolies();

            foreach(var poly in currentPolies)
            {
                this._selectedPolymorphs.Add(poly);
                this._availablePolymorphs.Remove(poly);
            }

            this.Update_Available_List();
            this.Update_Selected_List();
        }

        private List<string> ReadCurrentPolies()
        {
            var filePath = Path.Combine(this._config.InstallDir, "text.pak");
            var idxFile = filePath.Replace(".pak", ".idx");

            var indexes = PakTools.LoadIndexData(idxFile);
            var records = PakTools.CreateIndexRecords(indexes, true);
            var polyFile = records[11991];

            List<string> polyContents;

            using (var fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] numArray = new byte[polyFile.FileSize];
                fileStream.Seek((long)polyFile.Offset, SeekOrigin.Begin);
                fileStream.Read(numArray, 0, polyFile.FileSize);
                numArray = PakTools.Decode(numArray, 0);

                polyContents = Encoding.GetEncoding("big5")
                    .GetString(numArray).Split('\n').Select(b => Regex.Replace(b.Trim(), @"<[^>]*>", string.Empty))
                    .Where(b => b.Trim() != string.Empty && b != "Choose a monster.").ToList();
            }

            // it is the default file, so return an empty list since they haven't customized
            if(polyContents[0].IndexOf("<p><font fg=ffffff> Choose a monster. </p>") > -1)
            {
                return new List<string>();
            }

            return polyContents;
        }

        private void Update_Lists()
        {
            this.Update_Available_List();
            this.Update_Selected_List();
        }

        private void Update_Available_List()
        {
            this.lst_available.ClearSelected();
            this.lst_available.Items.Clear();
            foreach (var polymorph in _availablePolymorphs.OrderBy(b => b).ToList())
            {
                this.lst_available.Items.Add(polymorph);
            }
        }

        private void Update_Selected_List()
        {
            this.lst_selected.ClearSelected();
            this.lst_selected.Items.Clear();
            foreach (var polymorph in this._selectedPolymorphs)
            {
                this.lst_selected.Items.Add(polymorph);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach(var item in this.lst_available.SelectedItems)
            {
                this._selectedPolymorphs.Add(item.ToString());
                _availablePolymorphs.Remove(item.ToString());
            }

            this.Update_Lists();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            foreach (var item in this.lst_selected.SelectedItems)
            {
                // so we don't add headings back to the availablity list
                if(polyList.ContainsKey(item.ToString()))
                {
                    _availablePolymorphs.Add(item.ToString());
                }
                
                this._selectedPolymorphs.Remove(item.ToString());
            }

            this.Update_Lists();
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if(this.lst_selected.SelectedItems.Count > 1)
            {
                MessageBox.Show("You must have exactly 1 item selected to re-order.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedValue = this.lst_selected.SelectedItems[0].ToString();
            var newIndex = this._selectedPolymorphs.IndexOf(selectedValue) - 1;

            if(newIndex < 0)
            {
                return;
            }

            var tmp = this._selectedPolymorphs[newIndex];
            this._selectedPolymorphs[newIndex] = selectedValue;
            this._selectedPolymorphs[newIndex + 1] = tmp;

            this.Update_Selected_List();
            this.lst_selected.SelectedIndex = newIndex;
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (this.lst_selected.SelectedItems.Count > 1)
            {
                MessageBox.Show("You must have exactly 1 item selected to re-order.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedValue = this.lst_selected.SelectedItems[0].ToString();
            var newIndex = this._selectedPolymorphs.IndexOf(selectedValue) + 1;

            if (newIndex > this._selectedPolymorphs.Count - 1)
            {
                return;
            }

            var tmp = this._selectedPolymorphs[newIndex];
            this._selectedPolymorphs[newIndex] = selectedValue;
            this._selectedPolymorphs[newIndex - 1] = tmp;

            this.Update_Selected_List();
            this.lst_selected.SelectedIndex = newIndex;
        }

        private void btn_heading_Click(object sender, EventArgs e)
        {
            var inputDialog = new InputBox("Enter a heading");
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                this._selectedPolymorphs.Add(inputDialog.Input);
                this.Update_Selected_List();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will overwrite the current ingame polymorph list. Do you wish to continue?", "Continue?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var filePath = Path.Combine(this._config.InstallDir, "text.pak");

                var idxFile = filePath.Replace(".pak", ".idx");
                var pakIndex = PakTools.RebuildPak(filePath, new List<PakFile>
                {
                    new PakFile
                    {
                        Id = 11992,
                        FileName = "monlist-e.html",
                        Content = this.CreatePolylistHtml()
                    }
                }, true);

                PakTools.RebuildIndex(idxFile, pakIndex, true);

                MessageBox.Show("The polymorph list has been updated!", "Polylist Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string CreatePolylistHtml()
        {
            var polyHtml = new StringBuilder("<body>\n<p><font fg=ffffff>Choose a monster.</font></p>\n");

            foreach(var poly in this._selectedPolymorphs)
            {
                if(polyList.ContainsKey(poly))
                {
                    var polyDefinition = polyList[poly];
                    polyHtml.AppendLine("<a action=\"" + polyDefinition + "\">" + poly + "</a><br>");
                } else
                {
                    polyHtml.AppendLine("<br><font fg=ffffaf>" + poly + "</font><br><br>");
                }
            }

            return polyHtml.ToString() + "</body>";
        }
    }
}
