package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj26LogSozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �f�ވꗗ�ύX���OVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/03/09 HDX�Ή� HLC K.Soga)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj26LogSozaiKanriListVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /** �f�t�H���g�R���X�g���N�^ */
    public Tbj26LogSozaiKanriListVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj26LogSozaiKanriListVO();
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj26LogSozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param val �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj26LogSozaiKanriList.DCARCD, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSOZAIYM() {
        return (Date) get(Tbj26LogSozaiKanriList.SOZAIYM);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setSOZAIYM(Date val) {
        set(Tbj26LogSozaiKanriList.SOZAIYM, val);
    }

    /**
     * �쐬�敪���擾����
     *
     * @return �쐬�敪
     */
    public String getRECKBN() {
        return (String) get(Tbj26LogSozaiKanriList.RECKBN);
    }

    /**
     * �쐬�敪��ݒ肷��
     *
     * @param val �쐬�敪
     */
    public void setRECKBN(String val) {
        set(Tbj26LogSozaiKanriList.RECKBN, val);
    }

    /**
     * �쐬�ԍ����擾����
     *
     * @return �쐬�ԍ�
     */
    public String getRECNO() {
        return (String) get(Tbj26LogSozaiKanriList.RECNO);
    }

    /**
     * �쐬�ԍ���ݒ肷��
     *
     * @param val �쐬�ԍ�
     */
    public void setRECNO(String val) {
        set(Tbj26LogSozaiKanriList.RECNO, val);
    }

    /**
     * ����NO���擾����
     *
     * @return ����NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYNO() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.HISTORYNO);
    }

    /**
     * ����NO��ݒ肷��
     *
     * @param val ����NO
     */
    public void setHISTORYNO(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.HISTORYNO, val);
    }

    /**
     * �����敪���擾����
     *
     * @return �����敪
     */
    public String getHISTORYKBN() {
        return (String) get(Tbj26LogSozaiKanriList.HISTORYKBN);
    }

    /**
     * �����敪��ݒ肷��
     *
     * @param val �����敪
     */
    public void setHISTORYKBN(String val) {
        set(Tbj26LogSozaiKanriList.HISTORYKBN, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj26LogSozaiKanriList.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj26LogSozaiKanriList.DELFLG, val);
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCMCD() {
        return (String) get(Tbj26LogSozaiKanriList.CMCD);
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param val 10��CM����
     */
    public void setCMCD(String val) {
        set(Tbj26LogSozaiKanriList.CMCD, val);
    }

    /**
     * ��10��CM���ނ��擾����
     *
     * @return ��10��CM����
     */
    public String getTEMPCMCD() {
        return (String) get(Tbj26LogSozaiKanriList.TEMPCMCD);
    }

    /**
     * ��10��CM���ނ�ݒ肷��
     *
     * @param val ��10��CM����
     */
    public void setTEMPCMCD(String val) {
        set(Tbj26LogSozaiKanriList.TEMPCMCD, val);
    }

    /**
     * �^�C�g�����擾����
     *
     * @return �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj26LogSozaiKanriList.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     *
     * @param val �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj26LogSozaiKanriList.TITLE, val);
    }

    /**
     * �b�����擾����
     *
     * @return �b��
     */
    public String getSECOND() {
        return (String) get(Tbj26LogSozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     *
     * @param val �b��
     */
    public void setSECOND(String val) {
        set(Tbj26LogSozaiKanriList.SECOND, val);
    }

    /**
     * �f�ޗ��R�[�h���擾����
     *
     * @return �f�ޗ��R�[�h
     */
    public String getRCODE() {
        return (String) get(Tbj26LogSozaiKanriList.RCODE);
    }

    /**
     * �f�ޗ��R�[�h��ݒ肷��
     *
     * @param val �f�ޗ��R�[�h
     */
    public void setRCODE(String val) {
        set(Tbj26LogSozaiKanriList.RCODE, val);
    }

    /**
     * �\�Z���擾����
     *
     * @return �\�Z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTIMATE() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.ESTIMATE);
    }

    /**
     * �\�Z��ݒ肷��
     *
     * @param val �\�Z
     */
    public void setESTIMATE(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.ESTIMATE, val);
    }

    /**
     * OA�J�n�����擾����
     *
     * @return OA�J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj26LogSozaiKanriList.DATEFROM);
    }

    /**
     * OA�J�n����ݒ肷��
     *
     * @param val OA�J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj26LogSozaiKanriList.DATEFROM, val);
    }

    /**
     * OA�J�n��(����)���擾����
     *
     * @return OA�J�n��(����)
     */
    public String getDATEFROM_ATTR() {
        return (String) get(Tbj26LogSozaiKanriList.DATEFROM_ATTR);
    }

    /**
     * OA�J�n��(����)��ݒ肷��
     *
     * @param val OA�J�n��(����)
     */
    public void setDATEFROM_ATTR(String val) {
        set(Tbj26LogSozaiKanriList.DATEFROM_ATTR, val);
    }

    /**
     * OA�I�������擾����
     *
     * @return OA�I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj26LogSozaiKanriList.DATETO);
    }

    /**
     * OA�I������ݒ肷��
     *
     * @param val OA�I����
     */
    public void setDATETO(Date val) {
        set(Tbj26LogSozaiKanriList.DATETO, val);
    }

    /**
     * OA�I����(����)���擾����
     *
     * @return OA�I����(����)
     */
    public String getDATETO_ATTR() {
        return (String) get(Tbj26LogSozaiKanriList.DATETO_ATTR);
    }

    /**
     * OA�I����(����)��ݒ肷��
     *
     * @param val OA�I����(����)
     */
    public void setDATETO_ATTR(String val) {
        set(Tbj26LogSozaiKanriList.DATETO_ATTR, val);
    }

    /**
     * �V�f���׸ނ��擾����
     *
     * @return �V�f���׸�
     */
    public String getNEWFLG() {
        return (String) get(Tbj26LogSozaiKanriList.NEWFLG);
    }

    /**
     * �V�f���׸ނ�ݒ肷��
     *
     * @param val �V�f���׸�
     */
    public void setNEWFLG(String val) {
        set(Tbj26LogSozaiKanriList.NEWFLG, val);
    }

    /**
     * NEW�\�����擾����
     *
     * @return NEW�\��
     */
    public String getNEWDISPFLG() {
        return (String) get(Tbj26LogSozaiKanriList.NEWDISPFLG);
    }

    /**
     * NEW�\����ݒ肷��
     *
     * @param val NEW�\��
     */
    public void setNEWDISPFLG(String val) {
        set(Tbj26LogSozaiKanriList.NEWDISPFLG, val);
    }

    /**
     * Time�g�p�׸ނ��擾����
     *
     * @return Time�g�p�׸�
     */
    public String getTIMEUSE() {
        return (String) get(Tbj26LogSozaiKanriList.TIMEUSE);
    }

    /**
     * Time�g�p�׸ނ�ݒ肷��
     *
     * @param val Time�g�p�׸�
     */
    public void setTIMEUSE(String val) {
        set(Tbj26LogSozaiKanriList.TIMEUSE, val);
    }

    /**
     * Spot�g�p�׸ނ��擾����
     *
     * @return Spot�g�p�׸�
     */
    public String getSPOTUSE() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTUSE);
    }

    /**
     * Spot�g�p�׸ނ�ݒ肷��
     *
     * @param val Spot�g�p�׸�
     */
    public void setSPOTUSE(String val) {
        set(Tbj26LogSozaiKanriList.SPOTUSE, val);
    }

    /**
     * Spot�_�񖼂��擾����
     *
     * @return Spot�_��
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTCTRT);
    }

    /**
     * Spot�_�񖼂�ݒ肷��
     *
     * @param val Spot�_��
     */
    public void setSPOTCTRT(String val) {
        set(Tbj26LogSozaiKanriList.SPOTCTRT, val);
    }

    /**
     * Spot���Ԃ��擾����
     *
     * @return Spot����
     */
    public String getSPOTSPAN() {
        return (String) get(Tbj26LogSozaiKanriList.SPOTSPAN);
    }

    /**
     * Spot���Ԃ�ݒ肷��
     *
     * @param val Spot����
     */
    public void setSPOTSPAN(String val) {
        set(Tbj26LogSozaiKanriList.SPOTSPAN, val);
    }

    /**
     * Spot�\�Z���擾����
     *
     * @return Spot�\�Z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSPOTESTM() {
        return (BigDecimal) get(Tbj26LogSozaiKanriList.SPOTESTM);
    }

    /**
     * Spot�\�Z��ݒ肷��
     *
     * @param val Spot�\�Z
     */
    public void setSPOTESTM(BigDecimal val) {
        set(Tbj26LogSozaiKanriList.SPOTESTM, val);
    }

    /**
     * �g�p�\���Ԃ��擾����
     *
     * @return �g�p�\����
     */
    @XmlElement(required = true, nillable = true)
    public Date getLIMIT() {
        return (Date) get(Tbj26LogSozaiKanriList.LIMIT);
    }

    /**
     * �g�p�\���Ԃ�ݒ肷��
     *
     * @param val �g�p�\����
     */
    public void setLIMIT(Date val) {
        set(Tbj26LogSozaiKanriList.LIMIT, val);
    }

    /**
     * �Ԏ�S��(�d��)���擾����
     *
     * @return �Ԏ�S��(�d��)
     */
    public String getSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.SYATAN);
    }

    /**
     * �Ԏ�S��(�d��)��ݒ肷��
     *
     * @param val �Ԏ�S��(�d��)
     */
    public void setSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.SYATAN, val);
    }

    /**
     * �Ԏ�S��(���޺�ï�)���擾����
     *
     * @return �Ԏ�S��(���޺�ï�)
     */
    public String getHCSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.HCSYATAN);
    }

    /**
     * �Ԏ�S��(���޺�ï�)��ݒ肷��
     *
     * @param val �Ԏ�S��(���޺�ï�)
     */
    public void setHCSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.HCSYATAN, val);
    }

    /**
     * �Ԏ�S��(����)���擾����
     *
     * @return �Ԏ�S��(����)
     */
    public String getHMSYATAN() {
        return (String) get(Tbj26LogSozaiKanriList.HMSYATAN);
    }

    /**
     * �Ԏ�S��(����)��ݒ肷��
     *
     * @param val �Ԏ�S��(����)
     */
    public void setHMSYATAN(String val) {
        set(Tbj26LogSozaiKanriList.HMSYATAN, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj26LogSozaiKanriList.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj26LogSozaiKanriList.BIKO, val);
    }

    /**
     * HDX�J���׸ނ��擾����
     *
     * @return HDX�J���׸�
     */
    public String getOPENFLG() {
        return (String) get(Tbj26LogSozaiKanriList.OPENFLG);
    }

    /**
     * HDX�J���׸ނ�ݒ肷��
     *
     * @param val HDX�J���׸�
     */
    public void setOPENFLG(String val) {
        set(Tbj26LogSozaiKanriList.OPENFLG, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj26LogSozaiKanriList.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj26LogSozaiKanriList.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj26LogSozaiKanriList.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj26LogSozaiKanriList.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj26LogSozaiKanriList.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj26LogSozaiKanriList.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj26LogSozaiKanriList.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj26LogSozaiKanriList.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj26LogSozaiKanriList.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj26LogSozaiKanriList.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj26LogSozaiKanriList.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj26LogSozaiKanriList.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj26LogSozaiKanriList.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj26LogSozaiKanriList.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj26LogSozaiKanriList.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj26LogSozaiKanriList.UPDID, val);
    }
}