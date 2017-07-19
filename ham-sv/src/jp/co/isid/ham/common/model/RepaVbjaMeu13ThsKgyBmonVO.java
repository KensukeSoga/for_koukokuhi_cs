package jp.co.isid.ham.common.model;


import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ����敔��VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu13ThsKgyBmonVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu13ThsKgyBmonVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu13ThsKgyBmonVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.THSKGYCD, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SEQNO, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.STARTYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SNSTNT, val);
    }

    /**
     * �T�u�����擾����
     *
     * @return �T�u��
     */
    public String getSUBMEI() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBMEI);
    }

    /**
     * �T�u����ݒ肷��
     *
     * @param val �T�u��
     */
    public void setSUBMEI(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBMEI, val);
    }

    /**
     * �T�u���i�J�i�j���擾����
     *
     * @return �T�u���i�J�i�j
     */
    public String getSUBKN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBKN);
    }

    /**
     * �T�u���i�J�i�j��ݒ肷��
     *
     * @param val �T�u���i�J�i�j
     */
    public void setSUBKN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBKN, val);
    }

    /**
     * �T�u���i�p���j���擾����
     *
     * @return �T�u���i�p���j
     */
    public String getSUBEN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBEN);
    }

    /**
     * �T�u���i�p���j��ݒ肷��
     *
     * @param val �T�u���i�p���j
     */
    public void setSUBEN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBEN, val);
    }

    /**
     * �T�u���i�����p�J�i�j���擾����
     *
     * @return �T�u���i�����p�J�i�j
     */
    public String getSUBSRCHKN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN);
    }

    /**
     * �T�u���i�����p�J�i�j��ݒ肷��
     *
     * @param val �T�u���i�����p�J�i�j
     */
    public void setSUBSRCHKN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SUBSRCHKN, val);
    }

    /**
     * �Ǝ�i�咆���ށj���擾����
     *
     * @return �Ǝ�i�咆���ށj
     */
    public String getGSYLMCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GSYLMCD);
    }

    /**
     * �Ǝ�i�咆���ށj��ݒ肷��
     *
     * @param val �Ǝ�i�咆���ށj
     */
    public void setGSYLMCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GSYLMCD, val);
    }

    /**
     * ����������R�[�h���擾����
     *
     * @return ����������R�[�h
     */
    public String getGPIBKTSAKICD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD);
    }

    /**
     * ����������R�[�h��ݒ肷��
     *
     * @param val ����������R�[�h
     */
    public void setGPIBKTSAKICD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKICD, val);
    }

    /**
     * ����������r�d�p�m�n���擾����
     *
     * @return ����������r�d�p�m�n
     */
    public String getGPIBKTSAKISEQNO() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO);
    }

    /**
     * ����������r�d�p�m�n��ݒ肷��
     *
     * @param val ����������r�d�p�m�n
     */
    public void setGPIBKTSAKISEQNO(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.GPIBKTSAKISEQNO, val);
    }

    /**
     * �x����M�p�R�[�h���擾����
     *
     * @return �x����M�p�R�[�h
     */
    public String getSHRSINCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SHRSINCD);
    }

    /**
     * �x����M�p�R�[�h��ݒ肷��
     *
     * @param val �x����M�p�R�[�h
     */
    public void setSHRSINCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SHRSINCD, val);
    }

    /**
     * �{�Ўx�Ћ敪���擾����
     *
     * @return �{�Ўx�Ћ敪
     */
    public String getHNSHASSHAKBN() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN);
    }

    /**
     * �{�Ўx�Ћ敪��ݒ肷��
     *
     * @param val �{�Ўx�Ћ敪
     */
    public void setHNSHASSHAKBN(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.HNSHASSHAKBN, val);
    }

    /**
     * �x����E��R�[�h���擾����
     *
     * @return �x����E��R�[�h
     */
    public String getSHRSSKSYUCD() {
        return (String) get(RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD);
    }

    /**
     * �x����E��R�[�h��ݒ肷��
     *
     * @param val �x����E��R�[�h
     */
    public void setSHRSSKSYUCD(String val) {
        set(RepaVbjaMeu13ThsKgyBmon.SHRSSKSYUCD, val);
    }

}
