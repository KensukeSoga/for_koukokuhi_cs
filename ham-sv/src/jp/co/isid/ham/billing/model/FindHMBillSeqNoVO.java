package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM������(���ψČ��o�͏�SEQNO)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�Ή�(2016/02/04 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillSeqNoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �X�V�t���O */
    public static final String UPDATEFLG = "UPDATEFLG";

    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
    /** �V�[�P���XNo */
    public static final String ESTDETAILSEQNO = "ESTDETAILSEQNO";
    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMBillSeqNoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMBillSeqNoVO();
    }

    /**
     * �t�F�C�Y���擾����
     * @return BigDecimal �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val Date �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * ���ψČ��Ǘ��ԍ����擾����
     * @return BigDecimal ���ψČ��Ǘ��ԍ�
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ��ԍ���ݒ肷��
     * @param val BigDecimal ���ψČ��Ǘ��ԍ�
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    public String getESTIMATECLASS() {
        return (String) get(Tbj05EstimateItem.ESTIMATECLASS);
    }

    public void setESTIMATECLASS(String val) {
        set(Tbj05EstimateItem.ESTIMATECLASS, val);
    }

    /**
     * �O���[�v�R�[�h���擾����
     * @return BigDecimal �O���[�v�R�[�h
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGROUPCD() {
        return (BigDecimal) get(Tbj05EstimateItem.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     * @param val BigDecimal �O���[�v�R�[�h
     */
    public void setGROUPCD(BigDecimal val) {
        set(Tbj05EstimateItem.GROUPCD, val);
    }

    /**
     * ������O���[�v�}�X�^������O���[�v���擾����
     * @return String ������O���[�v�}�X�^������O���[�v
     */
    public String getMBJ26HCBUMONCDBILL() {
        return (String) get(Mbj26BillGroup.HCBUMONCDBILL);
     }

    /**
     * ������O���[�v�}�X�^������O���[�v��ݒ肷��
     * @param val String ������O���[�v�}�X�^������O���[�v
     */
    public void setMBJ26HCBUMONCDBILL(String val) {
        set(Mbj26BillGroup.HCBUMONCDBILL, val);
    }

    /**
     * �o�̓O���[�v���擾����
     * @return String �o�̓O���[�v
     */
    public String getOUTPUTGROUP() {
        return (String) get(Tbj06EstimateDetail.OUTPUTGROUP);
    }

    /**
     * �o�̓O���[�v��ݒ肷��
     * @param val String �o�̓O���[�v
     */
    public void setOUTPUTGROUP(String val) {
        set(Tbj06EstimateDetail.OUTPUTGROUP, val);
    }

    /**
     * ������O���[�v���擾����
     * @return String ������O���[�v
     */
    public String getHCBUMONCDBILL() {
        return (String) get(Tbj06EstimateDetail.HCBUMONCDBILL);
    }

    /**
     * ������O���[�v��ݒ肷��
     * @param val String ������O���[�v
     */
    public void setHCBUMONCDBILL(String val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILL, val);
    }

    /**
     * ������O���[�v�o�͏�SEQNO���擾����
     * @return BigDecimal ������O���[�v�o�͏�SEQNO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHCBUMONCDBILLSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO);
    }

    /**
     * ������O���[�v�o�͏�SEQNO��ݒ肷��
     * @param val String ������O���[�v�o�͏�SEQNO
     */
    public void setHCBUMONCDBILLSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }

    /**
     * �X�V�t���O���擾����
     * @return BigDecimal �X�V�t���O
     */
    public BigDecimal getUPDATEFLG() {
        return (BigDecimal) get(UPDATEFLG);
    }

    /**
     * �X�V�t���O��ݒ肷��
     * @param val BigDecimal �X�V�t���O
     */
    public void setUPDATEFLG(BigDecimal val) {
        set(UPDATEFLG, val);
    }

    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
    /**
     * �V�[�P���XNo���擾����
     * @return BigDecimal �V�[�P���XNo
     */
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * �V�[�P���XNo��ݒ肷��
     * @param val BigDecimal �V�[�P���XNo
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
    }
    /* 2016/02/02 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
}
