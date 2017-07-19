package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.RepaVbjaMeu19NbJk;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �l������VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class RepaVbjaMeu19NbJkVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RepaVbjaMeu19NbJkVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RepaVbjaMeu19NbJkVO();
    }

    /**
     * ������ƃR�[�h���擾����
     *
     * @return ������ƃR�[�h
     */
    public String getTHSKGYCD() {
        return (String) get(RepaVbjaMeu19NbJk.THSKGYCD);
    }

    /**
     * ������ƃR�[�h��ݒ肷��
     *
     * @param val ������ƃR�[�h
     */
    public void setTHSKGYCD(String val) {
        set(RepaVbjaMeu19NbJk.THSKGYCD, val);
    }

    /**
     * �r�d�p�m�n���擾����
     *
     * @return �r�d�p�m�n
     */
    public String getSEQNO() {
        return (String) get(RepaVbjaMeu19NbJk.SEQNO);
    }

    /**
     * �r�d�p�m�n��ݒ肷��
     *
     * @param val �r�d�p�m�n
     */
    public void setSEQNO(String val) {
        set(RepaVbjaMeu19NbJk.SEQNO, val);
    }

    /**
     * ��S���r�d�p�m�n���擾����
     *
     * @return ��S���r�d�p�m�n
     */
    public String getTRTNTSEQNO() {
        return (String) get(RepaVbjaMeu19NbJk.TRTNTSEQNO);
    }

    /**
     * ��S���r�d�p�m�n��ݒ肷��
     *
     * @param val ��S���r�d�p�m�n
     */
    public void setTRTNTSEQNO(String val) {
        set(RepaVbjaMeu19NbJk.TRTNTSEQNO, val);
    }

    /**
     * �l���\���m�n���擾����
     *
     * @return �l���\���m�n
     */
    public String getNBIKSINSEINO() {
        return (String) get(RepaVbjaMeu19NbJk.NBIKSINSEINO);
    }

    /**
     * �l���\���m�n��ݒ肷��
     *
     * @param val �l���\���m�n
     */
    public void setNBIKSINSEINO(String val) {
        set(RepaVbjaMeu19NbJk.NBIKSINSEINO, val);
    }

    /**
     * ���ϔN�����擾����
     *
     * @return ���ϔN��
     */
    public String getKESYM() {
        return (String) get(RepaVbjaMeu19NbJk.KESYM);
    }

    /**
     * ���ϔN����ݒ肷��
     *
     * @param val ���ϔN��
     */
    public void setKESYM(String val) {
        set(RepaVbjaMeu19NbJk.KESYM, val);
    }

    /**
     * �L���I���N�������擾����
     *
     * @return �L���I���N����
     */
    public String getENDYMD() {
        return (String) get(RepaVbjaMeu19NbJk.ENDYMD);
    }

    /**
     * �L���I���N������ݒ肷��
     *
     * @param val �L���I���N����
     */
    public void setENDYMD(String val) {
        set(RepaVbjaMeu19NbJk.ENDYMD, val);
    }

    /**
     * �L���J�n�N�������擾����
     *
     * @return �L���J�n�N����
     */
    public String getSTARTYMD() {
        return (String) get(RepaVbjaMeu19NbJk.STARTYMD);
    }

    /**
     * �L���J�n�N������ݒ肷��
     *
     * @param val �L���J�n�N����
     */
    public void setSTARTYMD(String val) {
        set(RepaVbjaMeu19NbJk.STARTYMD, val);
    }

    /**
     * �\���҃R�[�h���擾����
     *
     * @return �\���҃R�[�h
     */
    public String getSNSTNT() {
        return (String) get(RepaVbjaMeu19NbJk.SNSTNT);
    }

    /**
     * �\���҃R�[�h��ݒ肷��
     *
     * @param val �\���҃R�[�h
     */
    public void setSNSTNT(String val) {
        set(RepaVbjaMeu19NbJk.SNSTNT, val);
    }

    /**
     * �K�p�J�n�N�������擾����
     *
     * @return �K�p�J�n�N����
     */
    public String getTYSYMD() {
        return (String) get(RepaVbjaMeu19NbJk.TYSYMD);
    }

    /**
     * �K�p�J�n�N������ݒ肷��
     *
     * @param val �K�p�J�n�N����
     */
    public void setTYSYMD(String val) {
        set(RepaVbjaMeu19NbJk.TYSYMD, val);
    }

    /**
     * �K�p�I���N�������擾����
     *
     * @return �K�p�I���N����
     */
    public String getTYEYMD() {
        return (String) get(RepaVbjaMeu19NbJk.TYEYMD);
    }

    /**
     * �K�p�I���N������ݒ肷��
     *
     * @param val �K�p�I���N����
     */
    public void setTYEYMD(String val) {
        set(RepaVbjaMeu19NbJk.TYEYMD, val);
    }

    /**
     * ���ϓ����擾����
     *
     * @return ���ϓ�
     */
    public String getKESDAY() {
        return (String) get(RepaVbjaMeu19NbJk.KESDAY);
    }

    /**
     * ���ϓ���ݒ肷��
     *
     * @param val ���ϓ�
     */
    public void setKESDAY(String val) {
        set(RepaVbjaMeu19NbJk.KESDAY, val);
    }

    /**
     * �\���ǃR�[�h���擾����
     *
     * @return �\���ǃR�[�h
     */
    public String getSNSKYK() {
        return (String) get(RepaVbjaMeu19NbJk.SNSKYK);
    }

    /**
     * �\���ǃR�[�h��ݒ肷��
     *
     * @param val �\���ǃR�[�h
     */
    public void setSNSKYK(String val) {
        set(RepaVbjaMeu19NbJk.SNSKYK, val);
    }

}
