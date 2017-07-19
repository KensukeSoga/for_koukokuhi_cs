package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj48HmUser;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���[�U�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj48HmUserVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj48HmUserVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj48HmUserVO();
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Mbj48HmUser.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Mbj48HmUser.PHASE, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    public String getTERM() {
        return (String) get(Mbj48HmUser.TERM);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setTERM(String val) {
        set(Mbj48HmUser.TERM, val);
    }

    /**
     * HM�S���ҐE�Ԃ��擾����
     *
     * @return HM�S���ҐE��
     */
    public String getHMUSERCD() {
        return (String) get(Mbj48HmUser.HMUSERCD);
    }

    /**
     * HM�S���ҐE�Ԃ�ݒ肷��
     *
     * @param val HM�S���ҐE��
     */
    public void setHMUSERCD(String val) {
        set(Mbj48HmUser.HMUSERCD, val);
    }

    /**
     * HM�S���Җ����擾����
     *
     * @return HM�S���Җ�
     */
    public String getHMUSERNM() {
        return (String) get(Mbj48HmUser.HMUSERNM);
    }

    /**
     * HM�S���Җ���ݒ肷��
     *
     * @param val HM�S���Җ�
     */
    public void setHMUSERNM(String val) {
        set(Mbj48HmUser.HMUSERNM, val);
    }

    /**
     * HC�S���ғ����ԍ����擾����
     *
     * @return HC�S���ғ����ԍ�
     */
    public String getHMUSEREXTENSIONNO() {
        return (String) get(Mbj48HmUser.HMUSEREXTENSIONNO);
    }

    /**
     * HC�S���ғ����ԍ���ݒ肷��
     *
     * @param val HC�S���ғ����ԍ�
     */
    public void setHMUSEREXTENSIONNO(String val) {
        set(Mbj48HmUser.HMUSEREXTENSIONNO, val);
    }

    /**
     * �\�[�gNO���擾����
     *
     * @return �\�[�gNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj48HmUser.SORTNO);
    }

    /**
     * �\�[�gNO��ݒ肷��
     *
     * @param val �\�[�gNO
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj48HmUser.SORTNO, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj48HmUser.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj48HmUser.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj48HmUser.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj48HmUser.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj48HmUser.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj48HmUser.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj48HmUser.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj48HmUser.UPDID, val);
    }

}
