using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace innosys_infastructure
{
    public class InnosysContext: DbContext
    {
        public InnosysContext(DbContextOptions<InnosysContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

/*
 *  These are the database migration versions of Smart Cabinet database
 *  Format: YYYY-MM-dd - short summary of migration
 *
* | DATE USED  |   NAME                        |  Created Date & Purpose
* ====================================================================================================================================
* |            |   Zosma                       | 2021-05-22 - initial migration to add Activity and Task tables
* |            |   Zibal                       | 
* |            |   Zavijava                    | 
* |            |   Zaurak                      | 
* |            |   Zaniah                      | 
* |            |   Yildun                      | 
* |            |   Yed_Prior                   | 
* |            |   Yed_Posterior               | 
* |            |   Wezen                       | 
* |            |   Wazn                        | 
* |            |   Wasat                       | 
* |            |   Vindemiatrix                | 
* |            |   Veritate                    | 
* |            |   Vega                        | 
* |            |   Unukalhai                   | 
* |            |   Unukalhai_Dummy             | 
* |            |   Tyl                         | 
* |            |   Tureis                      | 
* |            |   Torcularis_Septentrionalis  | 
* |            |   Tonatiuh                    | 
* |            |   Titawin                     | 
* |            |   Tien_Kwan                   | 
* |            |   Thuban                      | 
* |            |   Theemin                     | 
* |            |   Thabit                      | 
* |            |   Terebellum                  | 
* |            |   Tejat_Prior                 | 
* |            |   Tejat                       | 
* |            |   Tegmine                     | 
* |            |   Taygeta                     | 
* |            |   Tarazed                     | 
* |            |   Tania_Borealis              | 
* |            |   Tania_Australis             | 
* |            |   Talitha_Australis           | 
* |            |   Talitha                     |
* |            |   Tabit                       |
* |            |   Syrma                       |
* |            |   Sulafat                     |
* |            |   Suhail                      |
* |            |   Subra                       |
* |            |   Sualocin                    |
* |            |   Sterope                     |
* |            |   Spica                       |
* |            |   Skat                        |
* |            |   Situla                      |
* |            |   Sirius                      |
* |            |   Sinistra                    |
* |            |   Sheratan                    |
* |            |   Sheliak                     |
* |            |   Shaula                      |
* |            |   Sham                        |
* |            |   Seginus                     |
* |            |   Segin                       |
* |            |   Scheddi                     |
* |            |   Schedar                     |
* |            |   Scheat                      |
* |            |   Sceptrum                    |
* |            |   Sarir                       |
* |            |   Sarin                       |
* |            |   Sargas                      |
* |            |   Salm                        |
* |            |   Saiph                       |
* |            |   Sadr                        |
* |            |   Sadatoni                    |
* |            |   Sadalsuud                   |
* |            |   Sadalmelik                  |
* |            |   Sadalbari                   |
* |            |   Sadachbia                   |
* |            |   Sabik                       |
* |            |   Rukbat                      |
* |            |   Ruchbah                     |
* |            |   Ruchba                      |
* |            |   Rotanev                     |
* |            |   Rijl_al_Awwa                |
* |            |   Rigil_Kentaurus             |
* |            |   Rigel                       |
* |            |   Regulus                     |
* |            |   Regor                       |
* |            |   Rastaban                    |
* |            |   Rasalhague                  |
* |            |   Rasalgethi                  |
* |            |   Rasalas                     |
* |            |   Ras_Elased_Australis        |
* |            |   Rana                        |
* |            |   Ran                         |
* |            |   Proxima_Centauri            |
* |            |   Propus                      |
* |            |   Procyon                     |
* |            |   Praecipua                   |
* |            |   Porrima                     |
* |            |   Pollux                      |
* |            |   Polaris_Australis           |
* |            |   Polaris                     |
* |            |   Pleione                     |
* |            |   Pherkard                    |
* |            |   Pherkad                     |
* |            |   Phecda                      |
* |            |   Phact                       |
* |            |   Peacock                     |
* |            |   Okul                        |
* |            |   Ogma                        |
* |            |   Nusakan                     |
* |            |   Nunki                       |
* |            |   Nihal                       |
* |            |   Nembus                      |
* |            |   Nekkar                      |
* |            |   Navi                        |
* |            |   Nashira                     |
* |            |   Nash                        |
* |            |   Naos                        |
* |            |   Nair_Al_Saif                |
* |            |   Musica                      |
* |            |   Muscida                     |
* |            |   Muscida                     |
* |            |   Murzim                      |
* |            |   Muphrid                     |
* |            |   Muliphein                   |
* |            |   Mothallah                   |
* |            |   Mizar                       |
* |            |   Misam                       |
* |            |   Mirzam                      |
* |            |   Mirfak                      |
* |            |   Miram                       |
* |            |   Mirach                      |
* |            |   Mira                        |
* |            |   Mintaka                     |
* |            |   Minkar                      |
* |            |   Minelava                    |
* |            |   Minchir                     |
* |            |   Mimosa                      |
* |            |   Miaplacidus                 |
* |            |   Mesarthim                   |
* |            |   Merope                      |
* |            |   Merga                       |
* |            |   Merak                       |
* |            |   Menkib                      |
* |            |   Menkent                     |
* |            |   Menkar                      |
* |            |   Menkalinan                  |
* |            |   Menkab                      |
* |            |   Mekbuda                     |
* |            |   Meissa                      |
* |            |   Megrez                      |
* |            |   Media                       |
* |            |   Mebsuta                     |
* |            |   Matar                       |
* |            |   Marsic                      |
* |            |   Markab                      |
* |            |   Marfik                      |
* |            |   Marfark                     |
* |            |   Maia                        |
* |            |   Mahasim                     |
* |            |   Maasym                      |
* |            |   Lucida_Anseris              |
* |            |   Libertas                    |
* |            |   Lesath                      |
* |            |   La Superba                  |
* |            |   Kurhah                      |
* |            |   Kuma                        |
* |            |   Kullat Nunu                 |
* |            |   Kraz                        |
* |            |   Kornephoros                 |
* |            |   Kochab                      |
* |            |   Kitalpha                    |
* |            |   Keid                        |
* |            |   Kaus Media                  |
* |            |   Kaus Borealis               |
* |            |   Kaus Australis              |
* |            |   Kastra                      |
* |            |   Kaffaljidhma                |
* |            |   Kabdhilinan                 |
* |            |   Jabbah                      |
* |            |   Izar                        |
* |            |   Intercrus                   |
* |            |   Hydrobius                   |
* |            |   Hyadum                      |
* |            |   Homam                       |
* |            |   Hoedus                      |
* |            |   Heze                        |
* |            |   Helvetios                   |
* |            |   Heka                        |
* |            |   Head of Hydrus              |
* |            |   Hassaleh                    |
* |            |   Hamal                       |
* |            |   Haedus                      |
* |            |   Hadar                       |
* |            |   Grumium                     |
* |            |   Graffias                    |
* |            |   Gorgonea Tertia             |
* |            |   Gomeisa                     |
* |            |   Girtab                      |
* |            |   Gienah                      |
* |            |   Giedi                       |
* |            |   Giausar                     |
* |            |   Gemma                       |
* |            |   Gatria                      |
* |            |   Garnet Star                 |
* |            |   Gacrux                      |
* |            |   Furud                       |
* |            |   Fum al Samakah              |
* |            |   Fomalhaut                   |
* |            |   Fafnir                      |
* |            |   Errai                       |
* |            |   Enif                        |
* |            |   Eltanin                     |
* |            |   Elnath                      |
* |            |   Elmuthalleth                |
* |            |   Electra                     |
* |            |   Edasich                     |
* |            |   Duhr                        |
* |            |   Dubhe                       |
* |            |   Dschubba                    |
* |            |   Dnoces                      |
* |            |   Diphda                      |
* |            |   Diadem                      |
* |            |   Dheneb                      |
* |            |   Denebola                    |
* |            |   Deneb Kaitos Schemali       |
* |            |   Deneb el Okab               |
* |            |   Deneb Dulfim                |
* |            |   Deneb Algedi                |
* |            |   Deneb                       |
* |            |   Dabih                       |
* |            |   Cursa                       |
* |            |   Cujam                       |
* |            |   Cor Caroli                  |
* |            |   Copernicus                  |
* |            |   Chow                        |
* |            |   Chertan                     |
* |            |   Cheleb                      |
* |            |   Chara                       |
* |            |   Chara                       |
* |            |   Chalawan                    |
* |            |   Cervantes                   |
* |            |   Celaeno                     |
* |            |   Cebalrai                    |
* |            |   Castor                      |
* |            |   Caph                        |
* |            |   Capella                     |
* |            |   Capella                     |
* |            |   Canopus                     |
* |            |   Bunda                       |
* |            |   Brachium                    |
* |            |   Botein                      |
* |            |   Biham                       |
* |            |   Betria                      |
* |            |   Betelgeuse                  |
* |            |   Benetnasch                  |
* |            |   Bellatrix                   |
* |            |   Beid                        |
* |            |   Baten Kaitos                |
* |            |   Barnard's Star              |
* |            |   Baham                       |
* |            |   Azmidiske                   |
* |            |   Azha                        |
* |            |   Azelfafage                  |
* |            |   Azaleh                      |
* |            |   Avior                       |
* |            |   Auva                        |
* |            |   Atria                       |
* |            |   Atlas                       |
* |            |   Atik                        |
* |            |   Asterope                    |
* |            |   Asterion                    |
* |            |   Aspidiske                   |
* |            |   Askella                     |
* |            |   Asellus Tertius             |
* |            |   Asellus Secundus            |
* |            |   Asellus Primus              |
* |            |   Asellus Borealis            |
* |            |   Asellus Australis           |
* |            |   Ascella                     |
* |            |   Arneb                       |
* |            |   Armus                       |
* |            |   Arkab Prior                 |
* |            |   Arkab Posterior             |
* |            |   Arich                       |
* |            |   Arcturus                    |
* |            |   Antares                     |
* |            |   Ankaa                       |
* |            |   Angetenar                   |
* |            |   Ancha                       |
* |            |   Alzir                       |
* |            |   Alya                        |
* |            |   Alwaid                      |
* |            |   Alula Borealis              |
* |            |   Alula Australis             |
* |            |   Aludra                      |
* |            |   Alterf                      |
* |            |   Altarf                      |
* |            |   Altais                      |
* |            |   Altair                      |
* |            |   Alshat                      |
* |            |   Alshain                     |
* |            |   Alsciaukat                  |
* |            |   Alsafi                      |
* |            |   Alrescha                    |
* |            |   Alrami                      |
* |            |   Alrakis                     |
* |            |   Alrai                       |
* |            |   Alpheratz                   |
* |            |   Alphecca                    |
* |            |   Alphard                     |
* |            |   Alniyat                     |
* |            |   Alnitak                     |
* |            |   Alnilam                     |
* |            |   Alnasl                      |
* |            |   Alnair                      |
* |            |   Almach                      |
* |            |   Almaaz                      |
* |            |   Alkurah                     |
* |            |   Alkes                       |
* |            |   Alkalurops                  |
* |            |   Alkaid                      |
* |            |   Alioth                      |
* |            |   Alhena                      |
* |            |   Algorab                     |
* |            |   Algol                       |
* |            |   Algieba                     |
* |            |   Algenib                     |
* |            |   Algedi                      |
* |            |   Alfirk                      |
* |            |   Alfecca Meridiana           |
* |            |   Aldib                       |
* |            |   Aldhibain                   |
* |            |   Aldhanab                    |
* |            |   Aldhafera                   |
* |            |   Alderamin                   |
* |            |   Aldebaran                   |
* |            |   Alcyone                     |
* |            |   Alcor                       |
* |            |   Alchiba                     |
* |            |   Albireo                     |
* |            |   Albali                      |
* |            |   Albaldah                    |
* |            |   Alathfar                    |
* |            |   Alaraph                     |
* |            |   Alamak                      |
* |            |   Aladfar                     |
* |            |   Al Thalimain                |
* |            |   Al Thalimain                |
* |            |   Al Minliar al Asad          |
* |            |   Al Kurud                    |
* |            |   Al Kaphrah                  |
* |            |   Al Kalb al Rai              |
* |            |   Al Giedi                    |
* |            |   Al Fawaris                  |
* |            |   Ain                         |
* |            |   Adhil                       |
* |            |   Adhara                      |
* |            |   Adhafera                    |
* |            |   Acubens                     |
* |            |   Acrux                       |
* |            |   Acrab                       |
* |            |   Achird                      |
* |            |   Achernar                    |
* |            |   Acamar                      |
* */
