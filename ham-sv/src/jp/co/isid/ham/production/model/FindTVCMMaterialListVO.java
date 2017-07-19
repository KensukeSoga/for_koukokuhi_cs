package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * TVCM�f�ވꗗ��񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �EHDX�Ή�(2016/03/07 K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindTVCMMaterialListVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindTVCMMaterialListVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindTVCMMaterialListVO();
    }

    /**
     * �Ԏ���擾����
     *
     * @return �Ԏ�
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ��ݒ肷��
     *
     * @param val �Ԏ�
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj20SozaiKanriList.SOZAIYM);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setSOZAIYM(Date val) {
        set(Tbj20SozaiKanriList.SOZAIYM, val);
    }

    /**
     * �쐬�敪���擾����
     *
     * @return �쐬�敪
     */
    public String getRECKBN() {
        return (String) get(Tbj20SozaiKanriList.RECKBN);
    }

    /**
     * �쐬�敪��ݒ肷��
     *
     * @param val �쐬�敪
     */
    public void setRECKBN(String val) {
        set(Tbj20SozaiKanriList.RECKBN, val);
    }

    /**
     * �쐬�ԍ����擾����
     *
     * @return �쐬�ԍ�
     */
    public String getRECNO() {
        return (String) get(Tbj20SozaiKanriList.RECNO);
    }

    /**
     * �쐬�ԍ���ݒ肷��
     *
     * @param val �쐬�ԍ�
     */
    public void setRECNO(String val) {
        set(Tbj20SozaiKanriList.RECNO, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj20SozaiKanriList.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj20SozaiKanriList.DELFLG, val);
    }

    /**
     * ���ʃR�[�h���擾����
     *
     * @return ���ʃR�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * ���ʃR�[�h��ݒ肷��
     *
     * @param val ���ʃR�[�h
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * ��10��CM���ނ��擾����
     *
     * @return ��10��CM����
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj20SozaiKanriList.TEMPCMCD);
    }

    /**
     * ��10��CM���ނ�ݒ肷��
     *
     * @param val ��10��CM����
     */
    public void setTEMPCMCD(String val) {
        set(Tbj20SozaiKanriList.TEMPCMCD, val);
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param val �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * ���R�[�h���擾����
     *
     * @return ���R�[�h
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * ���R�[�h��ݒ肷��
     *
     * @param val ���R�[�h
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * �V�f���׸ނ��擾����
     *
     * @return �V�f���׸�
     */
    public String getNEWFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWFLG);
    }

    /**
     * �V�f���׸ނ�ݒ肷��
     *
     * @param val �V�f���׸�
     */
    public void setNEWFLG(String val) {
        set(Tbj20SozaiKanriList.NEWFLG, val);
    }

    /**
     * NEW�\���׸ނ��擾����
     *
     * @return NEW�\���׸�
     */
    public String getNEWDISPFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWDISPFLG);
    }

    /**
     * NEW�\���׸ނ�ݒ肷��
     *
     * @param val NEW�\���׸�
     */
    public void setNEWDISPFLG(String val) {
        set(Tbj20SozaiKanriList.NEWDISPFLG, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj20SozaiKanriList.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj20SozaiKanriList.BIKO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj20SozaiKanriList.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj20SozaiKanriList.UPDDATE, val);
    }

    /**
     * Honda�Ԏ�S�����擾����
     *
     * @return Honda�Ԏ�S��
     */
    @XmlElement(required = true, nillable = true)
    public String getHMSYATAN() {
        return (String) get(Tbj20SozaiKanriList.HMSYATAN);
    }

    /**
     * Honda�Ԏ�S����ݒ肷��
     *
     * @param val Honda�Ԏ�S��
     */
    public void setHMSYATAN(String val) {
        set(Tbj20SozaiKanriList.HMSYATAN, val);
    }

    /**
     * HC�S�����擾����
     *
     * @return HC�S��
     */
    @XmlElement(required = true, nillable = true)
    public String getHCSYATAN() {
        return (String) get(Tbj20SozaiKanriList.HCSYATAN);
    }

    /**
     * HC�S����ݒ肷��
     *
     * @param val HC�S��
     */
    public void setHCSYATAN(String val) {
        set(Tbj20SozaiKanriList.HCSYATAN, val);
    }

    /**
     * �d�ʒS�����擾����
     *
     * @return �d�ʒS��
     */
    @XmlElement(required = true, nillable = true)
    public String getSYATAN() {
        return (String) get(Tbj20SozaiKanriList.SYATAN);
    }

    /**
     * �d�ʒS����ݒ肷��
     *
     * @param val �d�ʒS��
     */
    public void setSYATAN(String val) {
        set(Tbj20SozaiKanriList.SYATAN, val);
    }

    /**
     * �����J�n��(�{�f��)���擾����
     *
     * @return �����J�n��(�{�f��)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM_18() {
        return (Date) get(Tbj18SozaiKanriData.DATEFROM);
    }

    /**
     * �����J�n��(�{�f��)��ݒ肷��
     *
     * @param val �����J�n��(�{�f��)
     */
    public void setDATEFROM_18(Date val) {
        set(Tbj18SozaiKanriData.DATEFROM, val);
    }

    /**
     * �����J�n��(����)(�{�f��)���擾����
     *
     * @return �����J�n��(����)(�{�f��)
     */
    public String getDATEFROM_ATTR_18() {
        return (String) get(Tbj18SozaiKanriData.DATEFROM_ATTR);
    }

    /**
     * �����J�n��(�{�f��)(����)��ݒ肷��
     *
     * @param val �����J�n��(�{�f��)(����)
     */
    public void setDATEFROM_ATTR_18(String val) {
        set(Tbj18SozaiKanriData.DATEFROM_ATTR, val);
    }

    /**
     * �����I����(�{�f��)���擾����
     *
     * @return �����I����(�{�f��)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO_18() {
        return (Date) get(Tbj18SozaiKanriData.DATETO);
    }

    /**
     * �����I����(�{�f��)��ݒ肷��
     *
     * @param val �����I����(�{�f��)
     */
    public void setDATETO_18(Date val) {
        set(Tbj18SozaiKanriData.DATETO, val);
    }

    /**
    * �����I����(�{�f��)(����)���擾����
    *
    * @return �����I����(�{�f��)(����)
    */
   public String getDATETO_ATTR_18() {
       return (String) get(Tbj18SozaiKanriData.DATETO_ATTR);
   }

   /**
    * �����I����(�{�f��)(����)��ݒ肷��
    *
    * @param val �����I����(����)
    */
   public void setDATETO_ATTR_18(String val) {
       set(Tbj18SozaiKanriData.DATETO_ATTR, val);
   }

   /**
    * �����J�n��(���f��)���擾����
    *
    * @return �����J�n��(���f��)
    */
   @XmlElement(required = true, nillable = true)
   public Date getDATEFROM_36() {
       return (Date) get(Tbj36TempSozaiKanriData.DATEFROM);
   }

   /**
    * �����J�n��(���f��)��ݒ肷��
    *
    * @param val �����J�n��(���f��)
    */
   public void setDATEFROM_36(Date val) {
       set(Tbj36TempSozaiKanriData.DATEFROM, val);
   }

   /**
    * �����J�n��(���f��)(����)���擾����
    *
    * @return �����J�n��(���f��)(����)
    */
   public String getDATEFROM_ATTR_36() {
       return (String) get(Tbj36TempSozaiKanriData.DATEFROM_ATTR);
   }

   /**
//    * �����J�n��(���f��)(����)��ݒ肷��
    *
    * @param val �����J�n��(���f��)(����)
    */
   public void setDATEFROM_ATTR_36(String val) {
       set(Tbj36TempSozaiKanriData.DATEFROM_ATTR, val);
   }

   /**
    * �����I����(���f��)���擾����
    *
    * @return �����I����(���f��)
    */
   @XmlElement(required = true, nillable = true)
   public Date getDATETO_36() {
       return (Date) get(Tbj36TempSozaiKanriData.DATETO);
   }

   /**
    * �����I����(���f��)��ݒ肷��
    *
    * @param val �����I����(���f��)
    */
   public void setDATETO_36(Date val) {
       set(Tbj36TempSozaiKanriData.DATETO, val);
   }

   /**
    * �����I����(���f��)(����)���擾����
    *
    * @return �����I����(���f��)(����)
    */
   public String getDATETO_ATTR_36() {
       return (String) get(Tbj36TempSozaiKanriData.DATETO_ATTR);
   }

   /**
    * �����I����(���f��)(����)��ݒ肷��
    *
    * @param val �����I����(���f��)(����)
    */
   public void setDATETO_ATTR_36(String val) {
       set(Tbj36TempSozaiKanriData.DATETO_ATTR, val);
   }

   /**
    * �ʏ̃^�C�g�����擾����
    *
    * @return �ʏ̃^�C�g��
    */
   public String getALIASTITLE() {
       return (String) get(Tbj42SozaiKanriListCmn.ALIASTITLE);
   }

   /**
    * �ʏ̃^�C�g����ݒ肷��
    *
    * @param val �ʏ̃^�C�g��
    */
   public void setALIASTITLE(String val) {
       set(Tbj42SozaiKanriListCmn.ALIASTITLE, val);
   }

   /**
    * �Ԃ牺������擾����
    *
    * @return �Ԃ牺����
    */
   public String getENDTITLE() {
       return (String) get(Tbj42SozaiKanriListCmn.ENDTITLE);
   }

   /**
    * �Ԃ牺�����ݒ肷��
    *
    * @param val �Ԃ牺����
    */
   public void setENDTITLE(String val) {
       set(Tbj42SozaiKanriListCmn.ENDTITLE, val);
   }

   /**
    * BS/CS�g�p�t���O���擾����
    *
    * @return BS/CS�g�p�t���O
    */
   public String getBSCSUSE() {
       return (String) get(Tbj42SozaiKanriListCmn.BSCSUSE);
   }

   /**
    * BS/CS�g�p�t���O��ݒ肷��
    *
    * @param val BS/CS�g�p�t���O
    */
   public void setBSCSUSE(String val) {
       set(Tbj42SozaiKanriListCmn.BSCSUSE, val);
   }

   /**
    * Time�g�p�t���O���擾����
    *
    * @return Time�g�p�t���O
    */
   public String getTIMEUSE() {
       return (String) get(Tbj42SozaiKanriListCmn.TIMEUSE);
   }

   /**
    * Time�g�p�t���O��ݒ肷��
    *
    * @param val Time�g�p�t���O
    */
   public void setTIMEUSE(String val) {
       set(Tbj42SozaiKanriListCmn.TIMEUSE, val);
   }

   /**
    * Spot�g�p�t���O���擾����
    *
    * @return Spot�g�p�t���O
    */
   public String getSPOTUSE() {
       return (String) get(Tbj42SozaiKanriListCmn.SPOTUSE);
   }

   /**
    * Spot�g�p�t���O��ݒ肷��
    *
    * @param val Spot�g�p�t���O
    */
   public void setSPOTUSE(String val) {
       set(Tbj42SozaiKanriListCmn.SPOTUSE, val);
   }

   /**
    * Spot�_�񖼂��擾����
    *
    * @return Spot�_��
    */
   public String getSPOTCTRT() {
       return (String) get(Tbj42SozaiKanriListCmn.SPOTCTRT);
   }

   /**
    * Spot�_�񖼂�ݒ肷��
    *
    * @param val Spot�_��
    */
   public void setSPOTCTRT(String val) {
       set(Tbj42SozaiKanriListCmn.SPOTCTRT, val);
   }

   /**
    * Spot�J�n�����擾����
    *
    * @return Spot�J�n��
    */
   @XmlElement(required = true, nillable = true)
   public Date getSPOTFROM() {
       return (Date) get(Tbj42SozaiKanriListCmn.SPOTFROM);
   }

   /**
    * Spot�J�n����ݒ肷��
    *
    * @param val Spot�J�n��
    */
   public void setSPOTFROM(Date val) {
       set(Tbj42SozaiKanriListCmn.SPOTFROM, val);
   }

   /**
    * Spot�I�������擾����
    *
    * @return Spot�I����
    */
   @XmlElement(required = true, nillable = true)
   public Date getSPOTTO() {
       return (Date) get(Tbj42SozaiKanriListCmn.SPOTTO);
   }

   /**
    * Spot�I������ݒ肷��
    *
    * @param val Spot�I����
    */
   public void setSPOTTO(Date val) {
       set(Tbj42SozaiKanriListCmn.SPOTTO, val);
   }

   /**
    * �g�p�v�]���擾����
    *
    * @return �g�p�v�]
    */
   public String getHMORDER() {
       return (String) get(Tbj42SozaiKanriListCmn.HMORDER);
   }

   /**
    * �g�p�v�]��ݒ肷��
    *
    * @param val �g�p�v�]
    */
   public void setHMORDER(String val) {
       set(Tbj42SozaiKanriListCmn.HMORDER, val);
   }

   /**
    * �\�t�v�]�����擾����
    *
    * @return �\�t�v�]��
    */
   public String getLAYOUTORDER() {
       return (String) get(Tbj42SozaiKanriListCmn.LAYOUTORDER);
   }

   /**
    * �\�t�v�]����ݒ肷��
    *
    * @param val �\�t�v�]��
    */
   public void setLAYOUTORDER(String val) {
       set(Tbj42SozaiKanriListCmn.LAYOUTORDER, val);
   }

   /**
    * OA�s���Ԃ��擾����
    *
    * @return OA�s����
    */
   public String getOANGSPAN() {
       return (String) get(Tbj42SozaiKanriListCmn.OANGSPAN);
   }

   /**
    * OA�s���Ԃ�ݒ肷��
    *
    * @param val OA�s����
    */
   public void setOANGSPAN(String val) {
       set(Tbj42SozaiKanriListCmn.OANGSPAN, val);
   }

   /**
    * �^�[�Q�b�g���擾����
    *
    * @return �^�[�Q�b�g
    */
   public String getTARGET() {
       return (String) get(Tbj42SozaiKanriListCmn.TARGET);
   }

   /**
    * �^�[�Q�b�g��ݒ肷��
    *
    * @param val �^�[�Q�b�g
    */
   public void setTARGET(String val) {
       set(Tbj42SozaiKanriListCmn.TARGET, val);
   }

   /**
    * �Ԏ�NEWS���擾����
    *
    * @return �Ԏ�NEWS
    */
   public String getCARNEWS() {
       return (String) get(Tbj42SozaiKanriListCmn.CARNEWS);
   }

   /**
    * �Ԏ�NEWS��ݒ肷��
    *
    * @param val �Ԏ�NEWS
    */
   public void setCARNEWS(String val) {
       set(Tbj42SozaiKanriListCmn.CARNEWS, val);
   }

   /**
    * ����Ԏ�NEWS���擾����
    *
    * @return ����Ԏ�NEWS
    */
   public String getNEXTCARNEWS() {
       return (String) get(Tbj42SozaiKanriListCmn.NEXTCARNEWS);
   }

   /**
    * ����Ԏ�NEWS��ݒ肷��
    *
    * @param val ����Ԏ�NEWS
    */
   public void setNEXTCARNEWS(String val) {
       set(Tbj42SozaiKanriListCmn.NEXTCARNEWS, val);
   }

   /**
    * ����ި��g�p�L��(Ѱ�ް�����)���擾����
    *
    * @return ����ި��g�p�L��(Ѱ�ް�����)
    */
   public String getOTHERMEDIAUSE_MVCHL() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL);
   }

   /**
    * ����ި��g�p�L��(Ѱ�ް�����)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(Ѱ�ް�����)
    */
   public void setOTHERMEDIAUSE_MVCHL(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL, val);
   }

   /**
    * ����ި��g�p�L��(HondaYouTube)���擾����
    *
    * @return ����ި��g�p�L��(HondaYouTube)
    */
   public String getOTHERMEDIAUSE_YOUTUBE() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE);
   }

   /**
    * ����ި��g�p�L��(HondaYouTube)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(HondaYouTube)
    */
   public void setOTHERMEDIAUSE_YOUTUBE(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE, val);
   }

   /**
    * ����ި��g�p�L��(MXTV)���擾����
    *
    * @return ����ި��g�p�L��(MXTV)
    */
   public String getOTHERMEDIAUSE_MXTV() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV);
   }

   /**
    * ����ި��g�p�L��(MXTV)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(MXTV)
    */
   public void setOTHERMEDIAUSE_MXTV(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV, val);
   }

   /**
    * ����ި��g�p�L��(�����ް�)���擾����
    *
    * @return ����ި��g�p�L��(�����ް�)
    */
   public String getOTHERMEDIAUSE_KYOSERADM() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM);
   }

   /**
    * ����ި��g�p�L��(�����ް�)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(�����ް�)
    */
   public void setOTHERMEDIAUSE_KYOSERADM(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM, val);
   }

   /**
    * ����ި��g�p�L��(������޼ޮ�)���擾����
    *
    * @return ����ި��g�p�L��(������޼ޮ�)
    */
   public String getOTHERMEDIAUSE_CIRCUITVS() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS);
   }

   /**
    * ����ި��g�p�L��(������޼ޮ�)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(������޼ޮ�)
    */
   public void setOTHERMEDIAUSE_CIRCUITVS(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS, val);
   }

   /**
    * ����ި��g�p�L��(̫�Э�Ư���)���擾����
    *
    * @return ����ި��g�p�L��(̫�Э�Ư���)
    */
   public String getOTHERMEDIAUSE_FMJPN() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN);
   }

   /**
    * ����ި��g�p�L��(̫�Э�Ư���)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(̫�Э�Ư���)
    */
   public void setOTHERMEDIAUSE_FMJPN(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN, val);
   }

   /**
    * ����ި��g�p�L��(WTCC)���擾����
    *
    * @return ����ި��g�p�L��(WTCC)
    */
   public String getOTHERMEDIAUSE_WTCC() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC);
   }

   /**
    * ����ި��g�p�L��(WTCC)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(WTCC)
    */
   public void setOTHERMEDIAUSE_WTCC(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC, val);
   }

   /**
    * ����ި��g�p�L��(�\������1)���擾����
    *
    * @return ����ި��g�p�L��(�\������1)
    */
   public String getOTHERMEDIAUSE_OTHER1() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1);
   }

   /**
    * ����ި��g�p�L��(�\������1)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(�\������1)
    */
   public void setOTHERMEDIAUSE_OTHER1(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1, val);
   }

   /**
    * ����ި��g�p�L��(�\������2)���擾����
    *
    * @return ����ި��g�p�L��(�\������2)
    */
   public String getOTHERMEDIAUSE_OTHER2() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2);
   }

   /**
    * ����ި��g�p�L��(�\������2)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(�\������2)
    */
   public void setOTHERMEDIAUSE_OTHER2(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2, val);
   }

   /**
    * ����ި��g�p�L��(�\������3)���擾����
    *
    * @return ����ި��g�p�L��(�\������3)
    */
   public String getOTHERMEDIAUSE_OTHER3() {
       return (String) get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3);
   }

   /**
    * ����ި��g�p�L��(�\������3)��ݒ肷��
    *
    * @param val ����ި��g�p�L��(�\������3)
    */
   public void setOTHERMEDIAUSE_OTHER3(String val) {
       set(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3, val);
   }

   /**
    * �Ԏ햼���擾����
    *
    * @return �Ԏ햼
    */
   public String getCARNM() {
       return (String) get(Mbj05Car.CARNM);
   }

   /**
    * �Ԏ햼��ݒ肷��
    *
    * @param val �Ԏ햼
    */
   public void setCARNM(String val) {
       set(Mbj05Car.CARNM, val);
   }

}
