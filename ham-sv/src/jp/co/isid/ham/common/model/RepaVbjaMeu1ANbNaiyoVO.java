package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu1ANbNaiyo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �l�����eVO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu1ANbNaiyoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu1ANbNaiyoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu1ANbNaiyoVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.THSKGYCD, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SEQNO, val);
    }

    /**
     * ��S���r�d�p�m�n���擾����
     *
     * @return ��S���r�d�p�m�n
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO);
    }

    /**
     * ��S���r�d�p�m�n��ݒ肷��
     *
     * @param val ��S���r�d�p�m�n
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TRTNTSEQNO, val);
    }

    /**
     * �l���\���m�n���擾����
     *
     * @return �l���\���m�n
     */
    public String getNBIKSINSEINO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKSINSEINO);
    }

    /**
     * �l���\���m�n��ݒ肷��
     *
     * @param val �l���\���m�n
     */
    public void setNBIKSINSEINO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKSINSEINO, val);
    }

    /**
     * ���ϔN�����擾����
     *
     * @return ���ϔN��
     */
    public String getKESYM() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KESYM);
    }

    /**
     * ���ϔN����ݒ肷��
     *
     * @param val ���ϔN��
     */
    public void setKESYM(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KESYM, val);
    }

    /**
     * �\���r�d�p�m�n���擾����
     *
     * @return �\���r�d�p�m�n
     */
    public String getSNSSEQNO() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SNSSEQNO);
    }

    /**
     * �\���r�d�p�m�n��ݒ肷��
     *
     * @param val �\���r�d�p�m�n
     */
    public void setSNSSEQNO(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SNSSEQNO, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.STARTYMD, val);
    }

    /**
     * ���ϓ����擾����
     *
     * @return ���ϓ�
     */
    public String getKESDAY() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KESDAY);
    }

    /**
     * ���ϓ���ݒ肷��
     *
     * @param val ���ϓ�
     */
    public void setKESDAY(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KESDAY, val);
    }

    /**
     * �K�p�J�n�N�������擾����
     *
     * @return �K�p�J�n�N����
     */
    public String getTYSYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TYSYMD);
    }

    /**
     * �K�p�J�n�N������ݒ肷��
     *
     * @param val �K�p�J�n�N����
     */
    public void setTYSYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TYSYMD, val);
    }

    /**
     * �K�p�I���N�������擾����
     *
     * @return �K�p�I���N����
     */
    public String getTYEYMD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.TYEYMD);
    }

    /**
     * �K�p�I���N������ݒ肷��
     *
     * @param val �K�p�I���N����
     */
    public void setTYEYMD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.TYEYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu1ANbNaiyo.SNSTNT, val);
    }

    /**
     * �Ɩ��敪���擾����
     *
     * @return �Ɩ��敪
     */
    public String getGYOMKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.GYOMKBN);
    }

    /**
     * �Ɩ��敪��ݒ肷��
     *
     * @param val �Ɩ��敪
     */
    public void setGYOMKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.GYOMKBN, val);
    }

    /**
     * �}�̃R�[�h���擾����
     *
     * @return �}�̃R�[�h
     */
    public String getBTAICD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.BTAICD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     *
     * @param val �}�̃R�[�h
     */
    public void setBTAICD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.BTAICD, val);
    }

    /**
     * ��ڃR�[�h���擾����
     *
     * @return ��ڃR�[�h
     */
    public String getHMOKCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.HMOKCD);
    }

    /**
     * ��ڃR�[�h��ݒ肷��
     *
     * @param val ��ڃR�[�h
     */
    public void setHMOKCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.HMOKCD, val);
    }

    /**
     * �w�H�����擾����
     *
     * @return �w�H��
     */
    public String getROSENCD() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ROSENCD);
    }

    /**
     * �w�H����ݒ肷��
     *
     * @param val �w�H��
     */
    public void setROSENCD(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ROSENCD, val);
    }

    /**
     * �V�������E�n���敪���擾����
     *
     * @return �V�������E�n���敪
     */
    public String getMSCHUOCHIHKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN);
    }

    /**
     * �V�������E�n���敪��ݒ肷��
     *
     * @param val �V�������E�n���敪
     */
    public void setMSCHUOCHIHKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.MSCHUOCHIHKBN, val);
    }

    /**
     * ���ۋ敪���擾����
     *
     * @return ���ۋ敪
     */
    public String getKKSIKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.KKSIKBN);
    }

    /**
     * ���ۋ敪��ݒ肷��
     *
     * @param val ���ۋ敪
     */
    public void setKKSIKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.KKSIKBN, val);
    }

    /**
     * �d�k�E���ŁE���敪���擾����
     *
     * @return �d�k�E���ŁE���敪
     */
    public String getELSHANKKAKKBN() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.ELSHANKKAKKBN);
    }

    /**
     * �d�k�E���ŁE���敪��ݒ肷��
     *
     * @param val �d�k�E���ŁE���敪
     */
    public void setELSHANKKAKKBN(String val) {
        set(RepaVbjaMeu1ANbNaiyo.ELSHANKKAKKBN, val);
    }

    /**
     * �l�����e�敪�P���擾����
     *
     * @return �l�����e�敪�P
     */
    public String getNBIKNIYOKBN1() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1);
    }

    /**
     * �l�����e�敪�P��ݒ肷��
     *
     * @param val �l�����e�敪�P
     */
    public void setNBIKNIYOKBN1(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN1, val);
    }

    /**
     * �l�����e�敪�Q���擾����
     *
     * @return �l�����e�敪�Q
     */
    public String getNBIKNIYOKBN2() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2);
    }

    /**
     * �l�����e�敪�Q��ݒ肷��
     *
     * @param val �l�����e�敪�Q
     */
    public void setNBIKNIYOKBN2(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN2, val);
    }

    /**
     * �l�����e�敪�R���擾����
     *
     * @return �l�����e�敪�R
     */
    public String getNBIKNIYOKBN3() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3);
    }

    /**
     * �l�����e�敪�R��ݒ肷��
     *
     * @param val �l�����e�敪�R
     */
    public void setNBIKNIYOKBN3(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN3, val);
    }

    /**
     * �l�����e�敪�S���擾����
     *
     * @return �l�����e�敪�S
     */
    public String getNBIKNIYOKBN4() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4);
    }

    /**
     * �l�����e�敪�S��ݒ肷��
     *
     * @param val �l�����e�敪�S
     */
    public void setNBIKNIYOKBN4(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN4, val);
    }

    /**
     * �l�����e�敪�T���擾����
     *
     * @return �l�����e�敪�T
     */
    public String getNBIKNIYOKBN5() {
        return (String) get(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5);
    }

    /**
     * �l�����e�敪�T��ݒ肷��
     *
     * @param val �l�����e�敪�T
     */
    public void setNBIKNIYOKBN5(String val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKNIYOKBN5, val);
    }

    /**
     * �l�������擾����
     *
     * @return �l����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNBIKRITU() {
        return (BigDecimal) get(RepaVbjaMeu1ANbNaiyo.NBIKRITU);
    }

    /**
     * �l������ݒ肷��
     *
     * @param val �l����
     */
    public void setNBIKRITU(BigDecimal val) {
        set(RepaVbjaMeu1ANbNaiyo.NBIKRITU, val);
    }

}
