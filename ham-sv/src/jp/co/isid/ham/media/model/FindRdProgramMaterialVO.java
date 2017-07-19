package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���W�I�ԑg�o�^��ʑf�ޏ�񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdProgramMaterialVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �{�f�ށE���f�ދ敪 */
    public static final String MATERIALKBN = "MATERIALKBN";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindRdProgramMaterialVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindRdProgramMaterialVO();
    }

    /**
     * �Ԏ�R�[�h���擾����
     * @return String �Ԏ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     * @param val String �Ԏ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj20SozaiKanriList.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     * @return String �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     * @param val String �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getSozaiYm() {
        return (Date) get(Tbj20SozaiKanriList.SOZAIYM);
    }

    /**
     * �N����ݒ肷��
     * @param val Date �N��
     */
    public void setSOZAIYM(Date val) {
        set(Tbj20SozaiKanriList.SOZAIYM, val);
    }

    /**
     * �쐬�敪���擾����
     * @return String �쐬�敪
     */
    public String getRECKBN() {
        return (String) get(Tbj20SozaiKanriList.RECKBN);
    }

    /**
     * �쐬�敪��ݒ肷��
     * @param val String �쐬�敪
     */
    public void setRECKBN(String val) {
        set(Tbj20SozaiKanriList.RECKBN, val);
    }

    /**
     * �쐬�ԍ����擾����
     * @return String �쐬�ԍ�
     */
    public String getRECNO() {
        return (String) get(Tbj20SozaiKanriList.RECNO);
    }

    /**
     * �쐬�ԍ���ݒ肷��
     * @param val String �쐬�ԍ�
     */
    public void setRECNO(String val) {
        set(Tbj20SozaiKanriList.RECNO, val);
    }

    /**
     * �폜�t���O���擾����
     * @return String �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj20SozaiKanriList.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     * @param val String �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj20SozaiKanriList.DELFLG, val);
    }

    /**
     * ���ʃR�[�h���擾����
     * @return String ���ʃR�[�h
     */
    public String getCMCD() {
        return (String) get(Tbj20SozaiKanriList.CMCD);
    }

    /**
     * ���ʃR�[�h��ݒ肷��
     * @param val String ���ʃR�[�h
     */
    public void setCMCD(String val) {
        set(Tbj20SozaiKanriList.CMCD, val);
    }

    /**
     * �{�f�ށE���f�ދ敪���擾����
     * @return String �{�f�ށE���f�ދ敪
     */
    public String getMATERIALKBN() {
        return (String) get(MATERIALKBN);
    }

    /**
     * �{�f�ށE���f�ދ敪��ݒ肷��
     * @param val String �{�f�ށE���f�ދ敪
     */
    public void setMATERIALKBN(String val) {
        set(MATERIALKBN, val);
    }

    /**
     * �^�C�g�����擾����
     * @return String �^�C�g��
     */
    public String getTITLE() {
        return (String) get(Tbj20SozaiKanriList.TITLE);
    }

    /**
     * �^�C�g����ݒ肷��
     * @param val String �^�C�g��
     */
    public void setTITLE(String val) {
        set(Tbj20SozaiKanriList.TITLE, val);
    }

    /**
     * �b�����擾����
     * @return String �b��
     */
    public String getSECOND() {
        return (String) get(Tbj20SozaiKanriList.SECOND);
    }

    /**
     * �b����ݒ肷��
     * @param val String �b��
     */
    public void setSECOND(String val) {
        set(Tbj20SozaiKanriList.SECOND, val);
    }

    /**
     * ���R�[�h���擾����
     * @return String ���R�[�h
     */
    public String getRCODE() {
        return (String) get(Tbj20SozaiKanriList.RCODE);
    }

    /**
     * ���R�[�h��ݒ肷��
     * @param val String ���R�[�h
     */
    public void setRCODE(String val) {
        set(Tbj20SozaiKanriList.RCODE, val);
    }

    /**
     * �\�Z���擾����
     * @return BigDecimal �\�Z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTIMATE() {
        return (BigDecimal) get(Tbj20SozaiKanriList.ESTIMATE);
    }

    /**
     * �\�Z��ݒ肷��
     * @param val BigDecimal �\�Z
     */
    public void setESTIMATE(BigDecimal val) {
        set(Tbj20SozaiKanriList.ESTIMATE, val);
    }

    /**
     * �����J�n�����擾����
     * @return Date �����J�n��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj20SozaiKanriList.DATEFROM);
    }

    /**
     * �����J�n����ݒ肷��
     * @param val Date �����J�n��
     */
    public void setDATEFROM(Date val) {
        set(Tbj20SozaiKanriList.DATEFROM, val);
    }

    /**
     * �����I�������擾����
     * @return Date �����I����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj20SozaiKanriList.DATETO);
    }

    /**
     * �����I������ݒ肷��
     * @param val Date �����I����
     */
    public void setDATETO(Date val) {
        set(Tbj20SozaiKanriList.DATETO, val);
    }

    /**
     * �V�f�ރt���O���擾����
     * @return String �V�f�ރt���O
     */
    public String getNEWFLG() {
        return (String) get(Tbj20SozaiKanriList.NEWFLG);
    }

    /**
     * �V�f�ރt���O��ݒ肷��
     * @param val String �V�f�ރt���O
     */
    public void setNEWFLG(String val) {
        set(Tbj20SozaiKanriList.NEWFLG, val);
    }

    /**
     * �^�C���g�p�t���O���擾����
     * @return String �^�C���g�p�t���O
     */
    public String getTIMEUSE() {
        return (String) get(Tbj20SozaiKanriList.TIMEUSE);
    }

    /**
     * �^�C���g�p�t���O��ݒ肷��
     * @param val String �^�C���g�p�t���O
     */
    public void setTIMEUSE(String val) {
        set(Tbj20SozaiKanriList.TIMEUSE, val);
    }

    /**
     * �X�|�b�g�g�p�t���O���擾����
     * @return String �X�|�b�g�g�p�t���O
     */
    public String getSPOTUSE() {
        return (String) get(Tbj20SozaiKanriList.SPOTUSE);
    }

    /**
     * �X�|�b�g�g�p�t���O��ݒ肷��
     * @param val String �X�|�b�g�g�p�t���O
     */
    public void setSPOTUSE(String val) {
        set(Tbj20SozaiKanriList.SPOTUSE, val);
    }

    /**
     * �X�|�b�g�_�񖼂��擾����
     * @return String �X�|�b�g�_��
     */
    public String getSPOTCTRT() {
        return (String) get(Tbj20SozaiKanriList.SPOTCTRT);
    }

    /**
     * �X�|�b�g�_�񖼂�ݒ肷��
     * @param val String �X�|�b�g�_��
     */
    public void setSPOTCTRT(String val) {
        set(Tbj20SozaiKanriList.SPOTCTRT, val);
    }

    /**
     * �X�|�b�g���Ԃ��擾����
     * @return String �X�|�b�g����
     */
    public String getSPOTSPAN() {
        return (String) get(Tbj20SozaiKanriList.SPOTSPAN);
    }

    /**
     * �X�|�b�g���Ԃ�ݒ肷��
     * @param val String �X�|�b�g����
     */
    public void setSPOTSPAN(String val) {
        set(Tbj20SozaiKanriList.SPOTSPAN, val);
    }

    /**
     * �X�|�b�g�\�Z���擾����
     * @return BigDecimal �X�|�b�g�\�Z
     */
    public BigDecimal getSPOTESTM() {
        return (BigDecimal) get(Tbj20SozaiKanriList.SPOTESTM);
    }

    /**
     * �X�|�b�g�\�Z��ݒ肷��
     * @param val BigDecimal �X�|�b�g�\�Z
     */
    public void setSPOTESTM(BigDecimal val) {
        set(Tbj20SozaiKanriList.SPOTESTM, val);
    }

    /**
     * �g�p�\���Ԃ��擾����
     * @return Date �g�p�\����
     */
    @XmlElement(required = true, nillable = true)
    public Date getLIMIT() {
        return (Date) get(Tbj20SozaiKanriList.LIMIT);
    }

    /**
     * �g�p�\���Ԃ�ݒ肷��
     * @param val Date �g�p�\����
     */
    public void setLIMIT(Date val) {
        set(Tbj20SozaiKanriList.LIMIT, val);
    }

    /**
     * �Ԏ�S�����擾����
     * @return String �Ԏ�S��
     */
    public String getSYATAN() {
        return (String) get(Tbj20SozaiKanriList.SYATAN);
    }

    /**
     * �Ԏ�S����ݒ肷��
     * @param val String �Ԏ�S��
     */
    public void setSYATAN(String val) {
        set(Tbj20SozaiKanriList.SYATAN, val);
    }

    /**
     * ���l���擾����
     * @return String ���l
     */
    public String getBIKO() {
        return (String) get(Tbj20SozaiKanriList.BIKO);
    }

    /**
     * ���l��ݒ肷��
     * @param val String ���l
     */
    public void setBIKO(String val) {
        set(Tbj20SozaiKanriList.BIKO, val);
    }

    /**
     * �����F���擾����
     * @return String �����F
     */
    public String getFORECOLOR() {
        return (String) get(Tbj20SozaiKanriList.FORECOLOR);
    }

    /**
     * �����F��ݒ肷��
     * @param val String �����F
     */
    public void setFORECOLOR(String val) {
        set(Tbj20SozaiKanriList.FORECOLOR, val);
    }

    /**
     * �w�i�F���擾����
     * @return String �w�i�F
     */
    public String getBACKCOLOR() {
        return (String) get(Tbj20SozaiKanriList.BACKCOLOR);
    }

    /**
     * �w�i�F��ݒ肷��
     * @param val String �w�i�F
     */
    public void setBACKCOLOR(String val) {
        set(Tbj20SozaiKanriList.BACKCOLOR, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     * @return Date �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj20SozaiKanriList.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     * @param val String �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj20SozaiKanriList.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     * @return String �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj20SozaiKanriList.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     * @param val String �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj20SozaiKanriList.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     * @return String �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj20SozaiKanriList.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     * @param val String �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj20SozaiKanriList.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     * @return String �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj20SozaiKanriList.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     * @param val String �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj20SozaiKanriList.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     * @return Date �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj20SozaiKanriList.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     * @param val Date �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj20SozaiKanriList.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     * @return String �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj20SozaiKanriList.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     * @param val String �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj20SozaiKanriList.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     * @return String �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj20SozaiKanriList.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     * @param val String �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj20SozaiKanriList.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     * @return String �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj20SozaiKanriList.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     * @param val String �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj20SozaiKanriList.UPDID, val);
    }

}
