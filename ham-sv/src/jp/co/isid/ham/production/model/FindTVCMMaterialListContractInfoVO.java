package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.Date;
import javax.xml.bind.annotation.XmlElement;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * TVCM�f�ވꗗ�_���񌟍�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �EHDX�Ή�(2016/03/07 HLC K.Oki)<BR>
 * </P>
 *
 * @author K.Oki
 */

public class FindTVCMMaterialListContractInfoVO extends AbstractModel {

    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindTVCMMaterialListContractInfoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new FindTVCMMaterialListContractInfoVO();
    }

    /**
     * �Ԏ�R�[�h(�f�ވꗗ)���擾����
     *
     * @return �Ԏ�
     */
    public String getDCARCD_MTL() {
        return (String) get(Tbj20SozaiKanriList.DCARCD);
    }

    /**
     * �Ԏ�R�[�h(�f�ވꗗ)��ݒ肷��
     *
     * @param val �Ԏ�
     */
    public void setDCARCD_MTL(String val) {
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
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getCTRTKBN() {
        return (String) get(Tbj16ContractInfo.CTRTKBN);
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param val �_����
     */
    public void setCTRTKBN(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }

    /**
     * �Ԏ�R�[�h(�_����)���擾����
     *
     * @return �Ԏ�R�[�h(�_����)
     */
    public String getDCARCD_CTR() {
        return (String) get(Tbj16ContractInfo.DCARCD);
    }

    /**
     * �Ԏ�R�[�h(�_����)��ݒ肷��
     *
     * @param val �Ԏ�R�[�h(�_����)
     */
    public void setDCARCD_CTR(String val) {
        set(Tbj16ContractInfo.DCARCD, val);
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getCATEGORY() {
        return (String) get(Tbj16ContractInfo.CATEGORY);
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param val �J�e�S��
     */
    public void setCATEGORY(String val) {
        set(Tbj16ContractInfo.CATEGORY, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj16ContractInfo.DELFLG);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj16ContractInfo.DELFLG, val);
    }

    /**
     * ���̂��擾����
     *
     * @return ����
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * ���̂�ݒ肷��
     *
     * @param val ����
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * �_�����(From)���擾����
     *
     * @return �_�����(From)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATEFROM() {
        return (Date) get(Tbj16ContractInfo.DATEFROM);
    }

    /**
     * �_�����(From)��ݒ肷��
     *
     * @param val �_�����(From)
     */
    public void setDATEFROM(Date val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * �_�����(To)���擾����
     *
     * @return �_�����(To)
     */
    @XmlElement(required = true, nillable = true)
    public Date getDATETO() {
        return (Date) get(Tbj16ContractInfo.DATETO);
    }

    /**
     * �_�����(To)��ݒ肷��
     *
     * @param val �_�����(To)
     */
    public void setDATETO(Date val) {
        set(Tbj16ContractInfo.DATETO, val);
    }

    /**
     * �y�Ȗ����擾����
     *
     * @return �y�Ȗ�
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * �y�Ȗ���ݒ肷��
     *
     * @param val �y�Ȗ�
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * JASRAC�o�^���擾����
     *
     * @return JASRAC�o�^
     */
    public String getJASRACFLG() {
        return (String) get(Tbj16ContractInfo.JASRACFLG);
    }

    /**
     * JASRAC�o�^��ݒ肷��
     *
     * @param val JASRAC�o�^
     */
    public void setJASRACFLG(String val) {
        set(Tbj16ContractInfo.JASRACFLG, val);
    }

    /**
     * CD�������擾����
     *
     * @return CD����
     */
    public String getSALEFLG() {
        return (String) get(Tbj16ContractInfo.SALEFLG);
    }

    /**
     * CD������ݒ肷��
     *
     * @param val CD����
     */
    public void setSALEFLG(String val) {
        set(Tbj16ContractInfo.SALEFLG, val);
    }

    /**
     *  �Ԃ牺������擾����
     *
     * @return �Ԃ牺����
     */
    public String getENDTITLEFLG() {
        return (String) get(Tbj16ContractInfo.ENDTITLEFLG);
    }

    /**
     *  �Ԃ牺�����ݒ肷��
     *
     * @param val �Ԃ牺����
     */
    public void setENDTITLEFLG(String val) {
        set(Tbj16ContractInfo.ENDTITLEFLG, val);
    }

    /**
     *  �A�����W�E�I���W�i�����擾����
     *
     * @return �A�����W�E�I���W�i��
     */
    public String getARRGORGFLG() {
        return (String) get(Tbj16ContractInfo.ARRGORGFLG);
    }

    /**
     *  �A�����W�E�I���W�i����ݒ肷��
     *
     * @param val �A�����W�E�I���W�i��
     */
    public void setARRGORGFLG(String val) {
        set(Tbj16ContractInfo.ARRGORGFLG, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKO() {
        return (String) get(Tbj16ContractInfo.BIKO);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKO(String val) {
        set(Tbj16ContractInfo.BIKO, val);
    }

    /**
     * �����L�[���擾����
     *
     * @return �����L�[
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHISTORYKEY() {
        return (BigDecimal) get(Tbj16ContractInfo.HISTORYKEY);
    }

    /**
     * �����L�[��ݒ肷��
     *
     * @param val �����L�[
     */
    public void setHISTORYKEY(BigDecimal val) {
        set(Tbj16ContractInfo.HISTORYKEY, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj16ContractInfo.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj16ContractInfo.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj16ContractInfo.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj16ContractInfo.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj16ContractInfo.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj16ContractInfo.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj16ContractInfo.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj16ContractInfo.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj16ContractInfo.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj16ContractInfo.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj16ContractInfo.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj16ContractInfo.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj16ContractInfo.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj16ContractInfo.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj16ContractInfo.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj16ContractInfo.UPDID, val);
    }

}