package jp.co.isid.ham.login.model;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu12ThsKgy;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu13ThsKgyBmon;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu16Skukjk;
import jp.co.isid.nj.model.AbstractModel;

public class TksInfoVO extends AbstractModel {

	private static final long serialVersionUID = 7561739022049341403L;

	/**
     * �V�K�C���X�^���X���\�z���܂�
     */
    public TksInfoVO() {
    }

    /**
     * �V�K�C���X�^���X���\�z���܂�
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new TksInfoVO();
    }

    /**
     * ������ƃR�[�h���擾����
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.THSKGYCD, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.SEQNO, val);
    }

    /**
     * ��S���r�d�p�m�n���擾����
     *
     * @return ��S���r�d�p�m�n
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.TRTNTSEQNO);
    }

    /**
     * ��S���r�d�p�m�n��ݒ肷��
     *
     * @param val ��S���r�d�p�m�n
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.TRTNTSEQNO, val);
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSIKCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SIKCD);
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param val �g�D�R�[�h
     */
    public void setSIKCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.SIKCD, val);
    }

    /**
     * �L�����ƃR�[�h���擾����
     *
     * @return �L�����ƃR�[�h
     */
    public String getCLNTKGYCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.CLNTKGYCD);
    }

    /**
     * �L�����ƃR�[�h��ݒ肷��
     *
     * @param val �L�����ƃR�[�h
     */
    public void setCLNTKGYCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.CLNTKGYCD, val);
    }

    /**
     * �L����r�d�p�m�n���擾����
     *
     * @return �L����r�d�p�m�n
     */
    public String getCLNTSEQNO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.CLNTSEQNO);
    }

    /**
     * �L����r�d�p�m�n��ݒ肷��
     *
     * @param val �L����r�d�p�m�n
     */
    public void setCLNTSEQNO(String val) {
        set(RepaVbjaMeu14ThsTntTr.CLNTSEQNO, val);
    }

    /**
     * �M�p�R�[�h���擾����
     *
     * @return �M�p�R�[�h
     */
    public String getSINCD() {
        return (String) get(RepaVbjaMeu16Skukjk.SINCD);
    }

    /**
     * �M�p�R�[�h��ݒ肷��
     *
     * @param val �M�p�R�[�h
     */
    public void setSINCD(String val) {
        set(RepaVbjaMeu16Skukjk.SINCD, val);
    }

    /**
     * �㗝�X�敪���擾����
     *
     * @return �㗝�X�敪
     */
    public String getDTENKBN() {
        return (String) get(RepaVbjaMeu12ThsKgy.DTENKBN);
    }

    /**
     * �㗝�X�敪��ݒ肷��
     *
     * @param val �㗝�X�敪
     */
    public void setDTENKBN(String val) {
        set(RepaVbjaMeu12ThsKgy.DTENKBN, val);
    }

    /**
     * ������Ɩ��i�\���p�����j���擾����
     *
     * @return ������Ɩ��i�\���p�����j
     */
    public String getTHSKGYDISPKJ() {
        return (String) get(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ);
    }

    /**
     * ������Ɩ��i�\���p�����j��ݒ肷��
     *
     * @param val ������Ɩ��i�\���p�����j
     */
    public void setTHSKGYDISPKJ(String val) {
        set(RepaVbjaMeu12ThsKgy.THSKGYDISPKJ, val);
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
     * �g�D�R�[�h�i�ǁj���擾����
     *
     * @return �g�D�R�[�h�i�ǁj
     */
    public String getSIKCDKYK() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDKYK);
    }

    /**
     * �g�D�R�[�h�i�ǁj��ݒ肷��
     *
     * @param val �g�D�R�[�h�i�ǁj
     */
    public void setSIKCDKYK(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDKYK, val);
    }

    /**
     * �g�D�R�[�h�i���j���擾����
     *
     * @return �g�D�R�[�h�i���j
     */
    public String getSIKCDBU() {
        return (String) get(RepaVbjaMeu07SikKrSprd.SIKCDBU);
    }

    /**
     * �g�D�R�[�h�i���j��ݒ肷��
     *
     * @param val �g�D�R�[�h�i���j
     */
    public void setSIKCDBU(String val) {
        set(RepaVbjaMeu07SikKrSprd.SIKCDBU, val);
    }

    /**
     * ���\�����i�����j���擾����
     *
     * @return ���\�����i�����j
     */
    public String getBUHYOJIKJ() {
        return (String) get(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ);
    }

    /**
     * ���\�����i�����j��ݒ肷��
     *
     * @param val ���\�����i�����j
     */
    public void setBUHYOJIKJ(String val) {
        set(RepaVbjaMeu07SikKrSprd.BUHYOJIKJ, val);
    }

    /**
     * �������R�[�h���擾����
     *
     * @return �������R�[�h
     */
    public String getKYUTRCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.KYUTRCD);
    }

    /**
     * �������R�[�h��ݒ肷��
     *
     * @param val �������R�[�h
     */
    public void setKYUTRCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.KYUTRCD, val);
    }

}
