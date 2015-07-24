using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siteyonetim.Framework.Data
{
    public class entity
    {

        public class aidatdonem
        {
            public int did { get; set; }
            public int? yil { get; set; }
            public string donemi { get; set; }
            public DateTime? bas_tarihi { get; set; }
            public DateTime? bit_tarihi { get; set; }
            public int? isletmedef1 { get; set; }
            public int? isletmedef2 { get; set; }
        }
        public class donemler
        {
            public int did { get; set; }
            public int? yil { get; set; }
            public string donemi { get; set; }
            public DateTime? bas_tarihi { get; set; }
            public DateTime? bit_tarihi { get; set; }
            public int? isletmedef1 { get; set; }
            public int? isletmedef2 { get; set; }
        }
        public class firma
        {
            public int firma_ind { get; set; }
            public string firma_kodu { get; set; }
            public string firma_adi { get; set; }
            public string musteri_satici { get; set; }
            public string firma_unvani_1 { get; set; }
            public string firma_unvani_2 { get; set; }
            public string firma_adresi_1 { get; set; }
            public string firma_adresi_2 { get; set; }
            public string adres_semt { get; set; }
            public string adres_sehir { get; set; }
            public string vergi_dairesi { get; set; }
            public string vergi_no { get; set; }
            public string telefon1_no { get; set; }
            public string telefon2_no { get; set; }
            public string fax_no { get; set; }
            public string firma_sahibi { get; set; }
            public string firma_irtibat_kisi { get; set; }
            public string ikinci_adres1 { get; set; }
            public string ikinci_adres2 { get; set; }
            public string ikinci_adres_semt { get; set; }
            public string ikinci_adres_sehir { get; set; }
            public string ikinci_adres_tel_no { get; set; }
            public string aciklama { get; set; }
        }
        public class firmabilgi
        {
            public int firma_ind { get; set; }
            public string firma_kodu { get; set; }
            public string firma_unvani_1 { get; set; }
            public string firma_unvani_2 { get; set; }
            public string firma_adresi_1 { get; set; }
            public string firma_adresi_2 { get; set; }
            public string adres_semt { get; set; }
            public string adres_sehir { get; set; }
            public string vergi_dairesi { get; set; }
            public string vergi_no { get; set; }
            public string telefon1_no { get; set; }
            public string telefon2_no { get; set; }
            public string fax_no { get; set; }
            public string firma_sahibi { get; set; }
            public string firma_irtibat_kisi { get; set; }
            public string ikinci_adres1 { get; set; }
            public string ikinci_adres2 { get; set; }
            public string ikinci_adres_semt { get; set; }
            public string ikinci_adres_sehir { get; set; }
            public string ikinci_adres_tel_no { get; set; }
            public string yetkili1 { get; set; }
            public string yetkili1unvan { get; set; }
            public string yetkili2 { get; set; }
            public string yetkili2unvan { get; set; }
            public string yetkili3 { get; set; }
            public string yetkili3unvan { get; set; }
            public string sgk_no { get; set; }
            public string sgk_kullanici { get; set; }
            public string sgk_parola { get; set; }
            public string sgk_sifre { get; set; }
            public string bos1 { get; set; }
            public string bos2 { get; set; }
            public string bos3 { get; set; }
            public string bos4 { get; set; }
            public string bos5 { get; set; }
            public string bos6 { get; set; }
            public string bos7 { get; set; }
            public string bos8 { get; set; }
            public string bos9 { get; set; }
            public string bos10 { get; set; }
            public DateTime? isletme_kapama_tarihi { get; set; }
            public DateTime? aidat_kapama_tarihi { get; set; }
            public DateTime? faiz_kapama_tarihi { get; set; }
            public double? faiz_yillik { get; set; }
            public double? faiz_aylik { get; set; }
        }
        public class gelirtur
        {
            public int gidi { get; set; }
            public string anakodu { get; set; }
            public string kodu { get; set; }
            public string adi { get; set; }
            public int? kdvoran { get; set; }
            public string kdvdahil { get; set; }
            public string kdvotomatik { get; set; }
            public double? kesinti { get; set; }
            public string kesintiotomatik { get; set; }
            public string kimden { get; set; }
        }
        public class gidertur
        {
            public int gidi { get; set; }
            public string anakodu { get; set; }
            public string kodu { get; set; }
            public string adi { get; set; }
            public int? kdvoran { get; set; }
            public string kdvdahil { get; set; }
            public string kdvotomatik { get; set; }
            public double? kesinti { get; set; }
            public string kesintiotomatik { get; set; }
        }
        public class master
        {
            public string mids { get; set; }
        }
        public class sifreTable
        {
            public int sid { get; set; }
            public string kullanici { get; set; }
            public string sifre { get; set; }
            public string adi { get; set; }
            public string soyadi { get; set; }
            public string firmaadi { get; set; }
            public string firmaadres { get; set; }
            public string firmatel { get; set; }
            public string firmafax { get; set; }
            public string ekle { get; set; }
            public string degistir { get; set; }
            public string herksesigor { get; set; }
            public string herkesidegistir { get; set; }
            public string baskasirandevuver { get; set; }
        }
        public class stoktur
        {
            public int sidi { get; set; }
            public string stokkodu { get; set; }
            public string adi { get; set; }
            public string olcubirimi1 { get; set; }
            public string olcubirimi2 { get; set; }
            public string olcubirimi3 { get; set; }
            public int? kdvoran { get; set; }
            public string kdvdahil { get; set; }
            public string kdvotomatik { get; set; }
        }



        public class carihareket
        {
            public int chid { get; set; }
            public string cari_kodu { get; set; }
            public string cari_hesap_adi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public DateTime? vade_tarihi { get; set; }
            public double? borc_tutari { get; set; }
            public double? alacak_tutari { get; set; }
            public double? brut_tutar { get; set; }
            public double? vade_fark { get; set; }
            public double? cek_masraf { get; set; }
            public double? komisyon { get; set; }
            public int? cek_id { get; set; }
            public int? nakit_id { get; set; }
            public int? cek_iade_id { get; set; }
            public int? cek_ciro_id { get; set; }
            public string aciklama { get; set; }
            public string doviz_cinsi { get; set; }
            public double? doviz_alacak { get; set; }
            public double? doviz_borc { get; set; }
            public string hes_dov_cinsi { get; set; }
            public double? hes_doviz_alacak { get; set; }
            public double? hes_doviz_borc { get; set; }
            public double? kur_farki { get; set; }
            public double? BSMV { get; set; }
            public string vade_farki_dus { get; set; }
            public string masraf_dus { get; set; }
            public string BSMV_dus { get; set; }
            public double? bostutar1 { get; set; }
            public double? bostutar2 { get; set; }
            public double? bostutar3 { get; set; }
            public int? bosint1 { get; set; }
            public int? bosint2 { get; set; }
            public int? bosint3 { get; set; }
            public double? doviz_kuru { get; set; }
            public double? fatura_KDV { get; set; }
            public string fatura_no { get; set; }
            public string irsaliye_no { get; set; }
            public string fatura_seri { get; set; }
            public string irsaliye_seri { get; set; }
            public string islemturu { get; set; }
            public string bostext1 { get; set; }
            public string bostext2 { get; set; }
            public string bostext3 { get; set; }
        }
        public class nakit
        {
            public int nid { get; set; }
            public int? cekid { get; set; }
            public int? firmaid { get; set; }
            public string firmakodu { get; set; }
            public string firmaadi { get; set; }
            public int? bankaid { get; set; }
            public string bankakodu { get; set; }
            public string bankaadi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public DateTime? islem_vadesi { get; set; }
            public double? borc_tutar { get; set; }
            public double? alacak_tutar { get; set; }
            public string neden { get; set; }
            public string doviz_cinsi { get; set; }
            public double? doviz_borc { get; set; }
            public double? doviz_alacak { get; set; }
            public string hes_dov_cinsi { get; set; }
            public double? hes_doviz_borc { get; set; }
            public double? hes_doviz_alacak { get; set; }
            public string aciklama { get; set; }
            public double? kur_farki { get; set; }
            public double? doviz_kuru { get; set; }
            public double? fatura_KDV { get; set; }
            public string fatura_no { get; set; }
            public string fatura_seri { get; set; }
            public string irsaliye_no { get; set; }
            public string irsaliye_seri { get; set; }
            public int? uye_kayit_no { get; set; }
            public int? uye_kodu { get; set; }
            public string uye_adi_soyadi { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string dis_kapi_no { get; set; }
            public int? aidat_id { get; set; }
            public int? isletme_id { get; set; }
            public string aidat_var { get; set; }
            public string isletme_var { get; set; }
        }
        public class resimnakit
        {
            public int rid { get; set; }
            public int? cekid { get; set; }
            public int? firmaid { get; set; }
            public string resimadi { get; set; }
            public string firmakodu { get; set; }
            public string firmaadi { get; set; }
            public int? cirocekid { get; set; }
            public byte[] resim { get; set; }
            public string aciklama { get; set; }
            public int? nakidid { get; set; }
            public int? bordroid { get; set; }
        }




        public class aiadataktar
        {
            public int aid { get; set; }
            public DateTime? tarih { get; set; }
            public double? toplam_tutar { get; set; }
            public int? taksitsay { get; set; }
            public string aciklama { get; set; }
            public DateTime? kayittarihi { get; set; }
        }
       
        public class bankaaktar
        {
            public int bid { get; set; }
            public DateTime? tarih { get; set; }
            public DateTime? islemtarihi { get; set; }
            public string aciklama { get; set; }
            public int? toplamkayit { get; set; }
            public int? aktarilankayit { get; set; }
            public double? toplamtutar { get; set; }
            public string gelir_aktarim_turu { get; set; }
            public string cari_aktarim_turu { get; set; }
            public int? bosint { get; set; }
            public double? bosnumber { get; set; }
            public string bostekst { get; set; }
            public string gelir_kodu { get; set; }
            public string gelir_adi { get; set; }
        }
        public class borcalacak
        {
            public int bid { get; set; }
            public DateTime? tarih { get; set; }
            public double? borctoplam { get; set; }
            public double? alacaktoplam { get; set; }
            public string aciklama { get; set; }
            public DateTime? kayittarihi { get; set; }
            public int? kayitsay { get; set; }
        }
        public class bulunmayan
        {
            public int cid { get; set; }
            public int? yil { get; set; }
            public string ay { get; set; }
            public int? sicil_kodu { get; set; }
            public string adi_soyadi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public double? borc { get; set; }
            public double? alacak { get; set; }
            public string para_cinsi { get; set; }
            public int? bankaid { get; set; }
            public int? aidat1id { get; set; }
            public int? aidat2id { get; set; }
            public int? aidat3id { get; set; }
            public int? nakitid { get; set; }
            public string muh_kodu { get; set; }
            public string aciklama { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string dis_kapi_numarasi { get; set; }
            public string not { get; set; }
            public string bankahesap { get; set; }
        }
        public class cari
        {
            public int mid { get; set; }
            public string sicilkodu { get; set; }
            public string adi_soyadi { get; set; }
            public DateTime? tarih { get; set; }
            public DateTime? islem_vadesi { get; set; }
            public int? randevuno { get; set; }
            public string randevuyualan { get; set; }
            public int? r_alan_kodu { get; set; }
            public double? borc { get; set; }
            public double? alacak { get; set; }
            public int? tahsilatno { get; set; }
            public int? tahsilat_rand_no { get; set; }
            public string aciklama { get; set; }
            public string gorusen { get; set; }
            public int? gorusen_kodu { get; set; }
            public int? gorusme_no { get; set; }
        }

      
        public class isletgelir
        {
            public int idi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public string doviz_cinsi { get; set; }
            public string faturano { get; set; }
            public DateTime? faturatarihi { get; set; }
            public double? malbedeli { get; set; }
            public double? kdv { get; set; }
            public double? toplamtutar { get; set; }
            public string aciklama { get; set; }
            public int? bankaid { get; set; }
            public int? nakitid { get; set; }
            public int? kasaid { get; set; }
            public int? sicilhareketid { get; set; }
            public string islemturu { get; set; }
            public DateTime? islem_vadesi { get; set; }
            public string stokkodu { get; set; }
            public string stokadi { get; set; }
            public double? miktari { get; set; }
            public string cari_kodu { get; set; }
            public string cari_adi { get; set; }
            public int? mahsupid { get; set; }
            public double? stopajgelir { get; set; }
            public double? stopajkdv { get; set; }
            public string gelirturu { get; set; }
            public string geliranakodu { get; set; }
            public string geliradi { get; set; }
            public int? uye_sicil_kodu { get; set; }
            public int? uye_kayit_sicil_no { get; set; }
            public string uye_adi_soyadi { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string dis_kapi_no { get; set; }
            public string bostext1 { get; set; }
            public string bostext2 { get; set; }
            public string bostext3 { get; set; }
            public double? bosnumber1 { get; set; }
            public double? bosnumber2 { get; set; }
            public double? bosnumber3 { get; set; }
            public int? bosinteger1 { get; set; }
            public int? bosinteger2 { get; set; }
            public int? bosinteger3 { get; set; }
        }
        public class isletgider
        {
            public int idi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public string doviz_cinsi { get; set; }
            public string faturano { get; set; }
            public DateTime? faturatarihi { get; set; }
            public double? malbedeli { get; set; }
            public double? kdv { get; set; }
            public double? toplamtutar { get; set; }
            public string aciklama { get; set; }
            public int? bankaid { get; set; }
            public int? nakitid { get; set; }
            public int? kasaid { get; set; }
            public int? sicilhareketid { get; set; }
            public string islemturu { get; set; }
            public DateTime? islem_vadesi { get; set; }
            public string stokkodu { get; set; }
            public string stokadi { get; set; }
            public double? miktari { get; set; }
            public string cari_kodu { get; set; }
            public string cari_adi { get; set; }
            public int? mahsupid { get; set; }
            public double? stopajgelir { get; set; }
            public double? stopajkdv { get; set; }
            public string masrafturu { get; set; }
            public string masrafanaturu { get; set; }
            public string masrafadi { get; set; }
            public double? masrafkesintioran { get; set; }
            public double? masrafkesintitutar { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string dis_kapi_no { get; set; }
            public int? uye_id { get; set; }
            public int? uye_no { get; set; }
            public string uye_adi_soyadi { get; set; }
            public string mal_sahibi_oturan { get; set; }
        }
     
        public class sicilcarihar
        {
            public int cid { get; set; }
            public int? yil { get; set; }
            public string ay { get; set; }
            public int? sicil_kodu { get; set; }
            public int? sicil_kayitno_id { get; set; }
            public string adi_soyadi { get; set; }
            public DateTime? islem_tarihi { get; set; }
            public double? borc { get; set; }
            public double? alacak { get; set; }
            public string para_cinsi { get; set; }
            public int? bankaid { get; set; }
            public int? aidat1id { get; set; }
            public int? aidat2id { get; set; }
            public int? aidat3id { get; set; }
            public int? nakitid { get; set; }
            public int? isletmegelirid { get; set; }
            public int? isletmegiderid { get; set; }
            public string muh_kodu { get; set; }
            public string aciklama { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string dis_kapi_numarasi { get; set; }
            public string gorevi { get; set; }
            public string not { get; set; }
            public string bankahesap { get; set; }
            public DateTime? vadesi { get; set; }
            public DateTime? son_faiz_tarih { get; set; }
            public double? toplam_faiz { get; set; }
            public double? son_faiz { get; set; }
            public int? faiz_id { get; set; }
            public string oturan_adi_soyadi { get; set; }
            public string daire_sahibi_adi_soyadi { get; set; }
            public string aidat_turu { get; set; }
        }
        public class siciltablo
        {
            public int hid { get; set; }
            public int? sicil_kodu { get; set; }
            public string adi { get; set; }
            public string soyadi { get; set; }
            public DateTime? giris_tarihi { get; set; }
            public string tc_kimlik { get; set; }
            public string cinsiyeti { get; set; }
            public string dairesi { get; set; }
            public string blok { get; set; }
            public string kisim { get; set; }
            public string baba_adi { get; set; }
            public string anne_adi { get; set; }
            public string tel1 { get; set; }
            public string tel2 { get; set; }
            public string ceptel { get; set; }
            public string ceptel2 { get; set; }
            public string fax { get; set; }
            public string oturan_fax { get; set; }
            public string ev_adresi { get; set; }
            public string isadresi { get; set; }
            public string email { get; set; }
            public string oturan_mail { get; set; }
            public string web { get; set; }
            public string aciklama1 { get; set; }
            public string aciklama2 { get; set; }
            public string aciklama3 { get; set; }
            public string kiminyakini { get; set; }
            public int? oturan_kisi_sayisi { get; set; }
            public int? oturan_cocuk_sayisi { get; set; }
            public string oturan_tc_kimlik { get; set; }
            public DateTime? oturan_dogumtarihi { get; set; }
            public DateTime? oturan_giris_tarihi { get; set; }
            public double? aidattutar1 { get; set; }
            public string aidatvar1 { get; set; }
            public double? aidat1indirim { get; set; }
            public double? aidattutar2 { get; set; }
            public string aidatvar2 { get; set; }
            public double? aidat2indirim { get; set; }
            public double? aidattutar3 { get; set; }
            public string aidatvar3 { get; set; }
            public double? aidat3indirim { get; set; }
            public string oturan_bankahesapno { get; set; }
            public string oturan_adi { get; set; }
            public string oturan_soyadi { get; set; }
            public string oturan_tel1 { get; set; }
            public string oturan_tel2 { get; set; }
            public string oturan_cep1 { get; set; }
            public string oturan_cep2 { get; set; }
            public string oturan_email { get; set; }
            public string oturan_is_adresi { get; set; }
            public string onceki_oturan_adi { get; set; }
            public string onceki_oturan_soyadi { get; set; }
            public string onceki_oturan_tel { get; set; }
            public string onceki_oturan_cep { get; set; }
            public string onceki_oturan_is_adresi { get; set; }
            public DateTime? onceki_oturan_tasin_tarihi { get; set; }
            public DateTime? onceki_oturan_giris_tarihi { get; set; }
            public string onceki_ev_sahibi_adi { get; set; }
            public string onceki_ev_sahibi_soyadi { get; set; }
            public string onceki_ev_sahibi_tel { get; set; }
            public string onceki_ev_sahibi_adres { get; set; }
            public byte[] sahibi_foto { get; set; }
            public byte[] oturan_foto { get; set; }
            public byte[] eski_sahibi_foto { get; set; }
            public byte[] eski_oturan_foto { get; set; }
            public string bos_text1 { get; set; }
            public string bos_text2 { get; set; }
            public string bos_text3 { get; set; }
            public string bos_text4 { get; set; }
            public string bos_text5 { get; set; }
            public string bos_text6 { get; set; }
            public string bos_text7 { get; set; }
            public double? bos_number1 { get; set; }
            public double? bos_number2 { get; set; }
            public double? bos_number3 { get; set; }
            public double? bos_number4 { get; set; }
            public double? bos_number5 { get; set; }
            public double? bos_number6 { get; set; }
            public double? bos_number7 { get; set; }
            public string mahallesi { get; set; }
            public string caddesi { get; set; }
            public string sokak { get; set; }
            public string dis_kapi_numarasi { get; set; }
            public string eski_sahibi_aciklama { get; set; }
            public string eski_oturan_aciklama { get; set; }
        }
      

    }
}
