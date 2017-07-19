package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �����O���[�v�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj26BillGroupVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj26BillGroupVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj26BillGroupVO();
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Mbj26BillGroup.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Mbj26BillGroup.GROUPCD, val);
    }

    /**
     * �O���[�v�����擾����
     *
     * @return �O���[�v��
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * �O���[�v����ݒ肷��
     *
     * @param val �O���[�v��
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * �O���[�v��(���[)���擾����
     *
     * @return �O���[�v��(���[)
     */
    public String getGROUPNMRPT() {
        return (String) get(Mbj26BillGroup.GROUPNMRPT);
    }

    /**
     * �O���[�v��(���[)��ݒ肷��
     *
     * @param val �O���[�v��(���[)
     */
    public void setGROUPNMRPT(String val) {
        set(Mbj26BillGroup.GROUPNMRPT, val);
    }

    /**
     * �\�[�gNO���擾����
     *
     * @return �\�[�gNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Mbj26BillGroup.SORTNO);
    }

    /**
     * �\�[�gNO��ݒ肷��
     *
     * @param val �\�[�gNO
     */
    public void setSORTNO(BigDecimal val) {
        set(Mbj26BillGroup.SORTNO, val);
    }

    /**
     * HC����R�[�h���擾����
     *
     * @return HC����R�[�h
     */
    public String getHCBUMONCD() {
        return (String) get(Mbj26BillGroup.HCBUMONCD);
    }

    /**
     * HC����R�[�h��ݒ肷��
     *
     * @param val HC����R�[�h
     */
    public void setHCBUMONCD(String val) {
        set(Mbj26BillGroup.HCBUMONCD, val);
    }

    /**
     * HC����R�[�h(Fee�Č������p)���擾����
     *
     * @return HC����R�[�h(Fee�Č������p)
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Mbj26BillGroup.HCBUMONCDBILL);
    }

    /**
     * HC����R�[�h(Fee�Č������p)��ݒ肷��
     *
     * @param val HC����R�[�h(Fee�Č������p)
     */
    public void setHCBUMONCDBILL(String val) {
        set(Mbj26BillGroup.HCBUMONCDBILL, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj26BillGroup.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj26BillGroup.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj26BillGroup.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj26BillGroup.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mbj26BillGroup.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mbj26BillGroup.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj26BillGroup.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj26BillGroup.UPDID, val);
    }

}
