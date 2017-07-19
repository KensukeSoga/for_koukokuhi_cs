package jp.co.isid.ham.common.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj04MediaMngEstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �}�̔�ϖ��׊Ǘ�VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj04MediaMngEstimateDetailVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj04MediaMngEstimateDetailVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj04MediaMngEstimateDetailVO();
    }

    /**
     * �}�̔�Ǘ�No���擾����
     *
     * @return �}�̔�Ǘ�No
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMEDIAMNGNO() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.MEDIAMNGNO);
    }

    /**
     * �}�̔�Ǘ�No��ݒ肷��
     *
     * @param val �}�̔�Ǘ�No
     */
    public void setMEDIAMNGNO(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.MEDIAMNGNO, val);
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     *
     * @return ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     *
     * @param val ���ϖ��׊Ǘ�NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.ESTDETAILSEQNO, val);
    }

    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj04MediaMngEstimateDetail.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj04MediaMngEstimateDetail.PHASE, val);
    }

    /**
     * �N���擾����
     *
     * @return �N
     */
    public String getMDYEAR() {
        return (String) get(Tbj04MediaMngEstimateDetail.MDYEAR);
    }

    /**
     * �N��ݒ肷��
     *
     * @param val �N
     */
    public void setMDYEAR(String val) {
        set(Tbj04MediaMngEstimateDetail.MDYEAR, val);
    }

    /**
     * �����擾����
     *
     * @return ��
     */
    public String getMDMONTH() {
        return (String) get(Tbj04MediaMngEstimateDetail.MDMONTH);
    }

    /**
     * ����ݒ肷��
     *
     * @param val ��
     */
    public void setMDMONTH(String val) {
        set(Tbj04MediaMngEstimateDetail.MDMONTH, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj04MediaMngEstimateDetail.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param val �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj04MediaMngEstimateDetail.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param val �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     *
     * @return �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     *
     * @param val �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     *
     * @return �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj04MediaMngEstimateDetail.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     *
     * @param val �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj04MediaMngEstimateDetail.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj04MediaMngEstimateDetail.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj04MediaMngEstimateDetail.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj04MediaMngEstimateDetail.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj04MediaMngEstimateDetail.UPDID, val);
    }

}
