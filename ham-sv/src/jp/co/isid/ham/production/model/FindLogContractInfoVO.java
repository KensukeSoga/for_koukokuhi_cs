package jp.co.isid.ham.production.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �擾�����f�[�^���i�[����VO�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/02/15 �VHAM�`�[��)<BR>
 * �EHDX�Ή�(2016/02/24 HLC K.Oki)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindLogContractInfoVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindLogContractInfoVO() {
    }

    /**
     * ��Ƌ敪���擾����
     *
     * @return ��Ƌ敪
     */
    public String getHISTORYNM() {
        return (String) get("HISTORYNM");
    }

    /**
     * ��Ƌ敪��ݒ肷��
     *
     * @param val ��Ƌ敪
     */
    public void setHISTORYNM(String val) {
        set("HISTORYNM", val);
    }

    /**
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getCTRTKBNNAM() {
        return (String) get("CTRTKBNNAM");
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param val �_����
     */
    public void setCTRTKBNNAM(String val) {
        set("CTRTKBNNAM", val);
    }

    /**
     * �s�X�e�[�^�X���擾����
     *
     * @return �s�X�e�[�^�X
     */
    public String getROWST() {
        return (String) get("ROWST");
    }

    /**
     * �s�X�e�[�^�X��ݒ肷��
     *
     * @param val �s�X�e�[�^�X
     */
    public void setROWST(String val) {
        set("ROWST", val);
    }

    /**
     * ��X�e�[�^�X���擾����
     *
     * @return ��X�e�[�^�X
     */
    public String getCOLST() {
        return (String) get("COLST");
    }

    /**
     * ��X�e�[�^�X��ݒ肷��
     *
     * @param val ��X�e�[�^�X
     */
    public void setCOLST(String val) {
        set("COLST", val);
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj24LogContractInfo.CTRTNO);
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj24LogContractInfo.CTRTNO, val);
    }

    /**
     * ���_���ނ��擾����
     *
     * @return ���_����
     */
    public String getCTRTKBN() {
        return (String) get(Tbj24LogContractInfo.CTRTKBN);
    }

    /**
     * ���_���ނ�ݒ肷��
     *
     * @param val ���_����
     */
    public void setCTRTKBN(String val) {
        set(Tbj24LogContractInfo.CTRTKBN, val);
    }

    /**
     * �Ԏ���擾����
     *
     * @return �Ԏ�
     */
    public String getSHASHU() {
        return (String) get("SHASHU");
    }

    /**
     * �Ԏ��ݒ肷��
     *
     * @param val �Ԏ�
     */
    public void setSHASHU(String val) {
        set("SHASHU", val);
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCATEGORY() {
        return (String) get(Tbj24LogContractInfo.CATEGORY);
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setCATEGORY(String val) {
        set(Tbj24LogContractInfo.CATEGORY, val);
    }

    /**
     * �Ȗ����擾����
     *
     * @return �J�e�S��
     */
    public String getMUSIC() {
        return (String) get(Tbj24LogContractInfo.MUSIC);
    }

    /**
     * �Ȗ���ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setMUSIC(String val) {
        set(Tbj24LogContractInfo.MUSIC, val);
    }

    /**
     * �l���A�A�[�e�B�X�g���擾����
     *
     * @return �l���A�A�[�e�B�X�g
     */
    public String getNAMES() {
        return (String) get(Tbj24LogContractInfo.NAMES);
    }

    /**
     * �l���A�A�[�e�B�X�g��ݒ肷��
     *
     * @param val �l���A�A�[�e�B�X�g
     */
    public void setNAMES(String val) {
        set(Tbj24LogContractInfo.NAMES, val);
    }

    /**
     * �_�����(From)���擾����
     *
     * @return �_�����(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj24LogContractInfo.DATEFROM);
    }

    /**
     * �_�����(From)��ݒ肷��
     *
     * @param val �_�����(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj24LogContractInfo.DATEFROM, val);
    }

    /**
     * �_�����(To)���擾����
     *
     * @return �_�����(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj24LogContractInfo.DATETO);
    }

    /**
     * �_�����(To)��ݒ肷��
     *
     * @param val �_�����(To)
     */
    public void setDATETO(Date val) {
        set(Tbj24LogContractInfo.DATETO, val);
    }

    /**
     * JASRAC�o�^���擾����
     *
     * @return JASRAC�o�^
     */
    public String getJASRACFLG() {
        return (String) get(Tbj24LogContractInfo.JASRACFLG);
    }

    /**
     * JASRAC�o�^��ݒ肷��
     *
     * @param val JASRAC�o�^
     */
    public void setJASRACFLG(String val) {
        set(Tbj24LogContractInfo.JASRACFLG, val);
    }

    /**
     * CD�������擾����
     *
     * @return CD����
     */
    public String getSALEFLG() {
        return (String) get(Tbj24LogContractInfo.SALEFLG);
    }

    /**
     * CD������ݒ肷��
     *
     * @param val CD����
     */
    public void setSALEFLG(String val) {
        set(Tbj24LogContractInfo.SALEFLG, val);
    }

    /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
    /**
     * �Ԃ牺������擾����
     *
     * @return �Ԃ牺����
     */
    public String getENDTITLEFLG() {
        return (String) get(Tbj24LogContractInfo.ENDTITLEFLG);
    }

    /**
     * �Ԃ牺�����ݒ肷��
     *
     * @param val �Ԃ牺����
     */
    public void setENDTITLEFLG(String val) {
        set(Tbj24LogContractInfo.ENDTITLEFLG, val);
    }

    /**
     * �A�����W�E�I���W�i�����擾����
     *
     * @return �A�����W�E�I���W�i��
     */
    public String getARRGORGFLG() {
        return (String) get(Tbj24LogContractInfo.ARRGORGFLG);
    }

    /**
     * �A�����W�E�I���W�i����ݒ肷��
     *
     * @param val �A�����W�E�I���W�i��
     */
    public void setARRGORGFLG(String val) {
        set(Tbj24LogContractInfo.ARRGORGFLG, val);
    }
    /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj24LogContractInfo.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj24LogContractInfo.BIKO, val);
    }

    /**
     * �o�^�҂��擾����
     *
     * @return �o�^��
     */
    public String getCRTNM() {
        return (String) get(Tbj24LogContractInfo.CRTNM);
    }

    /**
     * �o�^�҂�ݒ肷��
     *
     * @param val �o�^��
     */
    public void setCRTNM(String val) {
        set(Tbj24LogContractInfo.CRTNM, val);
    }

    /**
     * �o�^�҂��擾����
     *
     * @return �o�^��
     */
    public String getCRTAPL() {
        return (String) get(Tbj24LogContractInfo.CRTAPL);
    }

    /**
     * �o�^�҂�ݒ肷��
     *
     * @param val �o�^��
     */
    public void setCRTAPL(String val) {
        set(Tbj24LogContractInfo.CRTAPL, val);
    }

    /**
     * �o�^��ID���擾����
     *
     * @return �o�^��ID
     */
    public String getCRTID() {
        return (String) get(Tbj24LogContractInfo.CRTID);
    }

    /**
     * �o�^��ID��ݒ肷��
     *
     * @param val �o�^��ID
     */
    public void setCRTID(String val) {
        set(Tbj24LogContractInfo.CRTID, val);
    }

    /**
     * �o�^�������擾����
     *
     * @return �o�^����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj24LogContractInfo.CRTDATE);
    }

    /**
     * �o�^������ݒ肷��
     *
     * @param val �o�^����
     */
    public void setCRTDATE(Date val) {
        set(Tbj24LogContractInfo.CRTDATE, val);
    }

    /**
     * �X�V�҂��擾����
     *
     * @return �X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj24LogContractInfo.UPDNM);
    }

    /**
     * �X�V�҂�ݒ肷��
     *
     * @param val �X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj24LogContractInfo.UPDNM, val);
    }

    /**
     * �X�V�������擾����
     *
     * @return �X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj24LogContractInfo.UPDDATE);
    }

    /**
     * �X�V������ݒ肷��
     *
     * @param val �X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj24LogContractInfo.UPDDATE, val);
    }

}
