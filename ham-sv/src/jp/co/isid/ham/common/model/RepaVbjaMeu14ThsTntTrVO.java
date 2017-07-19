package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu14ThsTntTr;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �����S���i��jVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu14ThsTntTrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu14ThsTntTrVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu14ThsTntTrVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
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
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu14ThsTntTr.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu14ThsTntTr.STARTYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu14ThsTntTr.SNSTNT, val);
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
     * �L����敪���擾����
     *
     * @return �L����敪
     */
    public String getCLNTKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.CLNTKBN);
    }

    /**
     * �L����敪��ݒ肷��
     *
     * @param val �L����敪
     */
    public void setCLNTKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.CLNTKBN, val);
    }

    /**
     * ���Ӑ�敪���擾����
     *
     * @return ���Ӑ�敪
     */
    public String getTKKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.TKKBN);
    }

    /**
     * ���Ӑ�敪��ݒ肷��
     *
     * @param val ���Ӑ�敪
     */
    public void setTKKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.TKKBN, val);
    }

    /**
     * ������敪���擾����
     *
     * @return ������敪
     */
    public String getSKYUSKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SKYUSKBN);
    }

    /**
     * ������敪��ݒ肷��
     *
     * @param val ������敪
     */
    public void setSKYUSKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.SKYUSKBN, val);
    }

    /**
     * ������敪���擾����
     *
     * @return ������敪
     */
    public String getNKINSKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.NKINSKBN);
    }

    /**
     * ������敪��ݒ肷��
     *
     * @param val ������敪
     */
    public void setNKINSKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.NKINSKBN, val);
    }

    /**
     * �������Ӑ�敪���擾����
     *
     * @return �������Ӑ�敪
     */
    public String getMKMTKSKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.MKMTKSKBN);
    }

    /**
     * �������Ӑ�敪��ݒ肷��
     *
     * @param val �������Ӑ�敪
     */
    public void setMKMTKSKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.MKMTKSKBN, val);
    }

    /**
     * �c�Ɣ�Ӑ�敪���擾����
     *
     * @return �c�Ɣ�Ӑ�敪
     */
    public String getEGHISHRSKBN() {
        return (String) get(RepaVbjaMeu14ThsTntTr.EGHISHRSKBN);
    }

    /**
     * �c�Ɣ�Ӑ�敪��ݒ肷��
     *
     * @param val �c�Ɣ�Ӑ�敪
     */
    public void setEGHISHRSKBN(String val) {
        set(RepaVbjaMeu14ThsTntTr.EGHISHRSKBN, val);
    }

    /**
     * �\���m�n���擾����
     *
     * @return �\���m�n
     */
    public String getSINSEINO() {
        return (String) get(RepaVbjaMeu14ThsTntTr.SINSEINO);
    }

    /**
     * �\���m�n��ݒ肷��
     *
     * @param val �\���m�n
     */
    public void setSINSEINO(String val) {
        set(RepaVbjaMeu14ThsTntTr.SINSEINO, val);
    }

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return �c�Ə��R�[�h
     */
    public String getEGSYOCD() {
        return (String) get(RepaVbjaMeu14ThsTntTr.EGSYOCD);
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     *
     * @param val �c�Ə��R�[�h
     */
    public void setEGSYOCD(String val) {
        set(RepaVbjaMeu14ThsTntTr.EGSYOCD, val);
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

    /**
     * ��S���\�����擾����
     *
     * @return ��S���\��
     */
    public String getTRTNTYOBI() {
        return (String) get(RepaVbjaMeu14ThsTntTr.TRTNTYOBI);
    }

    /**
     * ��S���\����ݒ肷��
     *
     * @param val ��S���\��
     */
    public void setTRTNTYOBI(String val) {
        set(RepaVbjaMeu14ThsTntTr.TRTNTYOBI, val);
    }

}
