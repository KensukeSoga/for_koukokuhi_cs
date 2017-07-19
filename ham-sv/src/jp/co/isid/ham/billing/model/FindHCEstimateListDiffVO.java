package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj22SeisakuhiSs;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC���ψꗗ�ύX�m�F�f�[�^�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/2/6 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDiffVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHCEstimateListDiffVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListDiffVO();
    }


    /**
     * �t�F�C�Y���擾����
     *
     * @return �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     *
     * @param val �t�F�C�Y
     */
    public void setPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * �N�����擾����
     *
     * @return �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * �N����ݒ肷��
     *
     * @param val �N��
     */
    public void setCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     *
     * @return ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     *
     * @param val ���ψČ��Ǘ�NO
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj05EstimateItem.ESTSEQNO, val);
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     *
     * @return ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     *
     * @param val ���ϖ��׊Ǘ�NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
    }

    /**
     * �����Ǘ�NO���擾����
     *
     * @return �����Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSEQUENCENO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param val �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.SEQUENCENO, val);
    }

    /**
     * �d�ʎԎ�R�[�h(�����捞)���擾����
     *
     * @return �d�ʎԎ�R�[�h(�����捞)
     */
    public String getCptDCARCD() {
        return (String) get(Tbj22SeisakuhiSs.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h(�����捞)��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h(�����捞)
     */
    public void setCptDCARCD(String val) {
        set(Tbj22SeisakuhiSs.DCARCD, val);
    }

    /**
     * �d�ʎԎ�R�[�h(���ψČ�CR�����)���擾����
     *
     * @return �d�ʎԎ�R�[�h(���ψČ�CR�����)
     */
    public String getEstDCARCD() {
        return (String) get(Tbj07EstimateCreate.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h(���ψČ�CR�����)
     */
    public void setEstDCARCD(String val) {
        set(Tbj07EstimateCreate.DCARCD, val);
    }

    /**
     * �N��(�����捞)���擾����
     *
     * @return �N��(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptCRDATE() {
        return (Date) get(Tbj22SeisakuhiSs.CRDATE);
    }

    /**
     * �N��(�����捞)��ݒ肷��
     *
     * @param val �N��(�����捞)
     */
    public void setCptCRDATE(Date val) {
        set(Tbj22SeisakuhiSs.CRDATE, val);
    }

    /**
     * �N��(���ψČ�CR�����)���擾����
     *
     * @return �N��(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstCRDATE() {
        return (Date) get(Tbj07EstimateCreate.CRDATE);
    }

    /**
     * �N��(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �N��(���ψČ�CR�����)
     */
    public void setEstCRDATE(Date val) {
        set(Tbj07EstimateCreate.CRDATE, val);
    }

    /**
     * ��ʔ��f�t���O(�����捞)���擾����
     *
     * @return ��ʔ��f�t���O(�����捞)
     */
    public String getCptCLASSDIV() {
        return (String) get(Tbj22SeisakuhiSs.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O(�����捞)��ݒ肷��
     *
     * @param val ��ʔ��f�t���O(�����捞)
     */
    public void setCptCLASSDIV(String val) {
        set(Tbj22SeisakuhiSs.CLASSDIV, val);
    }

    /**
     * ��ʔ��f�t���O(���ψČ�CR�����)���擾����
     *
     * @return ��ʔ��f�t���O(���ψČ�CR�����)
     */
    public String getEstCLASSDIV() {
        return (String) get(Tbj07EstimateCreate.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ��ʔ��f�t���O(���ψČ�CR�����)
     */
    public void setEstCLASSDIV(String val) {
        set(Tbj07EstimateCreate.CLASSDIV, val);
    }

    /**
     * �\�Z���ރR�[�h(�����捞)���擾����
     *
     * @return �\�Z���ރR�[�h(�����捞)
     */
    public String getCptCLASSCD() {
        return (String) get(Tbj22SeisakuhiSs.CLASSCD);
    }

    /**
     * �\�Z���ރR�[�h(�����捞)��ݒ肷��
     *
     * @param val �\�Z���ރR�[�h(�����捞)
     */
    public void setCptCLASSCD(String val) {
        set(Tbj22SeisakuhiSs.CLASSCD, val);
    }

    /**
     * �\�Z���ރR�[�h(���ψČ�CR�����)���擾����
     *
     * @return �\�Z���ރR�[�h(���ψČ�CR�����)
     */
    public String getEstCLASSCD() {
        return (String) get(Tbj07EstimateCreate.CLASSCD);
    }

    /**
     * �\�Z���ރR�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �\�Z���ރR�[�h(���ψČ�CR�����)
     */
    public void setEstCLASSCD(String val) {
        set(Tbj07EstimateCreate.CLASSCD, val);
    }

    /**
     * �\�Z�\��ڃR�[�h(�����捞)���擾����
     *
     * @return �\�Z�\��ڃR�[�h
     */
    public String getCptEXPCD() {
        return (String) get(Tbj22SeisakuhiSs.EXPCD);
    }

    /**
     * �\�Z�\��ڃR�[�h(�����捞)��ݒ肷��
     *
     * @param val �\�Z�\��ڃR�[�h
     */
    public void setCptEXPCD(String val) {
        set(Tbj22SeisakuhiSs.EXPCD, val);
    }

    /**
     * �\�Z�\��ڃR�[�h(���ψČ�CR�����)���擾����
     *
     * @return �\�Z�\��ڃR�[�h(���ψČ�CR�����)
     */
    public String getEstEXPCD() {
        return (String) get(Tbj07EstimateCreate.EXPCD);
    }

    /**
     * �\�Z�\��ڃR�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �\�Z�\��ڃR�[�h(���ψČ�CR�����)
     */
    public void setEstEXPCD(String val) {
        set(Tbj07EstimateCreate.EXPCD, val);
    }

    /**
     * ���(�����捞)���擾����
     *
     * @return ���(�����捞)
     */
    public String getCptEXPENSE() {
        return (String) get(Tbj22SeisakuhiSs.EXPENSE);
    }

    /**
     * ���(�����捞)��ݒ肷��
     *
     * @param val ���(�����捞)
     */
    public void setCptEXPENSE(String val) {
        set(Tbj22SeisakuhiSs.EXPENSE, val);
    }

    /**
     * ���(���ψČ�CR�����)���擾����
     *
     * @return ���(���ψČ�CR�����)
     */
    public String getEstEXPENSE() {
        return (String) get(Tbj07EstimateCreate.EXPENSE);
    }

    /**
     * ���(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���(���ψČ�CR�����)
     */
    public void setEstEXPENSE(String val) {
        set(Tbj07EstimateCreate.EXPENSE, val);
    }

    /**
     * ���ϋ��z(�����捞)���擾����
     *
     * @return ���ϋ��z(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptESTMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.ESTMONEY);
    }

    /**
     * ���ϋ��z(�����捞)��ݒ肷��
     *
     * @param val ���ϋ��z(�����捞)
     */
    public void setCptESTMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.ESTMONEY, val);
    }

    /**
     * ���ϋ��z(���ψČ�CR�����)���擾����
     *
     * @return ���ϋ��z(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstESTMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.ESTMONEY);
    }

    /**
     * ���ϋ��z(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���ϋ��z(���ψČ�CR�����)
     */
    public void setEstESTMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.ESTMONEY, val);
    }

    /**
     * �������z(�����捞)���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptCLMMONEY() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.CLMMONEY);
    }

    /**
     * �������z(�����捞)��ݒ肷��
     *
     * @param val �������z
     */
    public void setCptCLMMONEY(BigDecimal val) {
        set(Tbj22SeisakuhiSs.CLMMONEY, val);
    }

    /**
     * �������z(���ψČ�CR�����)���擾����
     *
     * @return �������z(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstCLMMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.CLMMONEY);
    }

    /**
     * �������z(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �������z(���ψČ�CR�����)
     */
    public void setEstCLMMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.CLMMONEY, val);
    }

    /**
     * �敪�R�[�h(�����捞)���擾����
     *
     * @return �敪�R�[�h(�����捞)
     */
    public String getCptDIVCD() {
        return (String) get(Tbj22SeisakuhiSs.DIVCD);
    }

    /**
     * �敪�R�[�h(�����捞)��ݒ肷��
     *
     * @param val �敪�R�[�h(�����捞)
     */
    public void setCptDIVCD(String val) {
        set(Tbj22SeisakuhiSs.DIVCD, val);
    }

    /**
     * �敪�R�[�h(���ψČ�CR�����)���擾����
     *
     * @return �敪�R�[�h(���ψČ�CR�����)
     */
    public String getEstDIVCD() {
        return (String) get(Tbj07EstimateCreate.DIVCD);
    }

    /**
     * �敪�R�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �敪�R�[�h(���ψČ�CR�����)
     */
    public void setEstDIVCD(String val) {
        set(Tbj07EstimateCreate.DIVCD, val);
    }

    /**
     * �O���[�v�R�[�h(�����捞)���擾����
     *
     * @return �O���[�v�R�[�h(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptGROUPCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h(�����捞)��ݒ肷��
     *
     * @param val �O���[�v�R�[�h(�����捞)
     */
    public void setCptGROUPCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.GROUPCD, val);
    }

    /**
     * �O���[�v�R�[�h(���ψČ�CR�����)���擾����
     *
     * @return �O���[�v�R�[�h(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstGROUPCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �O���[�v�R�[�h(���ψČ�CR�����)
     */
    public void setEstGROUPCD(BigDecimal val) {
        set(Tbj07EstimateCreate.GROUPCD, val);
    }

    /**
     * ���ԊJ�n(�����捞)���擾����
     *
     * @return ���ԊJ�n(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptKIKANS() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANS);
    }

    /**
     * ���ԊJ�n(�����捞)��ݒ肷��
     *
     * @param val ���ԊJ�n(�����捞)
     */
    public void setCptKIKANS(Date val) {
        set(Tbj22SeisakuhiSs.KIKANS, val);
    }

    /**
     * ���ԊJ�n(���ψČ�CR�����)���擾����
     *
     * @return ���ԊJ�n(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstKIKANS() {
        return (Date) get(Tbj07EstimateCreate.KIKANS);
    }

    /**
     * ���ԊJ�n(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���ԊJ�n(���ψČ�CR�����)
     */
    public void setEstKIKANS(Date val) {
        set(Tbj07EstimateCreate.KIKANS, val);
    }

    /**
     * ���ԏI��(�����捞)���擾����
     *
     * @return ���ԏI��(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptKIKANE() {
        return (Date) get(Tbj22SeisakuhiSs.KIKANE);
    }

    /**
     * ���ԏI��(�����捞)��ݒ肷��
     *
     * @param val ���ԏI��(�����捞)
     */
    public void setCptKIKANE(Date val) {
        set(Tbj22SeisakuhiSs.KIKANE, val);
    }

    /**
     * ���ԏI��(���ψČ�CR�����)���擾����
     *
     * @return ���ԏI��(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstKIKANE() {
        return (Date) get(Tbj07EstimateCreate.KIKANE);
    }

    /**
     * ���ԏI��(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���ԏI��(���ψČ�CR�����)
     */
    public void setEstKIKANE(Date val) {
        set(Tbj07EstimateCreate.KIKANE, val);
    }

    /**
     * �x����[�i��(�����捞)���擾����
     *
     * @return �x����[�i��(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptDELIVERDAY() {
        return (Date) get(Tbj22SeisakuhiSs.DELIVERDAY);
    }

    /**
     * �x����[�i��(�����捞)��ݒ肷��
     *
     * @param val �x����[�i��(�����捞)
     */
    public void setCptDELIVERDAY(Date val) {
        set(Tbj22SeisakuhiSs.DELIVERDAY, val);
    }

    /**
     * �x����[�i��(���ψČ�CR�����)���擾����
     *
     * @return �x����[�i��(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstDELIVERDAY() {
        return (Date) get(Tbj07EstimateCreate.DELIVERDAY);
    }

    /**
     * �x����[�i��(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �x����[�i��(���ψČ�CR�����)
     */
    public void setEstDELIVERDAY(Date val) {
        set(Tbj07EstimateCreate.DELIVERDAY, val);
    }

    /**
     * �ݒ茎(�����捞)���擾����
     *
     * @return �ݒ茎(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCptSETMONTH() {
        return (Date) get(Tbj22SeisakuhiSs.SETMONTH);
    }

    /**
     * �ݒ茎(�����捞)��ݒ肷��
     *
     * @param val �ݒ茎(�����捞)
     */
    public void setCptSETMONTH(Date val) {
        set(Tbj22SeisakuhiSs.SETMONTH, val);
    }

    /**
     * �ݒ茎(���ψČ�CR�����)���擾����
     *
     * @return �ݒ茎(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public Date getEstSETMONTH() {
        return (Date) get(Tbj07EstimateCreate.SETMONTH);
    }

    /**
     * �ݒ茎(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �ݒ茎(���ψČ�CR�����)
     */
    public void setEstSETMONTH(Date val) {
        set(Tbj07EstimateCreate.SETMONTH, val);
    }

    /**
     * �ݒ�ǃi���o�[(�����捞)���擾����
     *
     * @return �ݒ�ǃi���o�[(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptSTKYKNO() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.STKYKNO);
    }

    /**
     * �ݒ�ǃi���o�[(�����捞)��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[(�����捞)
     */
    public void setCptSTKYKNO(BigDecimal val) {
        set(Tbj22SeisakuhiSs.STKYKNO, val);
    }

    /**
     * �ݒ�ǃi���o�[(���ψČ�CR�����)���擾����
     *
     * @return �ݒ�ǃi���o�[(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstSTKYKNO() {
        return (BigDecimal) get(Tbj07EstimateCreate.STKYKNO);
    }

    /**
     * �ݒ�ǃi���o�[(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[(���ψČ�CR�����)
     */
    public void setEstSTKYKNO(BigDecimal val) {
        set(Tbj07EstimateCreate.STKYKNO, val);
    }

    /**
     * �ݒ�ǖ�(�����捞)���擾����
     *
     * @return �ݒ�ǖ�(�����捞)
     */
    public String getCptSTKYKNM() {
        return (String) get("CPTSTKYKNM");
    }

    /**
     * �ݒ�ǖ�(�����捞)��ݒ肷��
     *
     * @param val �ݒ�ǖ�(�����捞)
     */
    public void setCptSTKYKNM(String val) {
        set("CPTSTKYKNM", val);
    }

    /**
     * �ݒ�ǖ�(���ψČ�CR�����)���擾����
     *
     * @return �ݒ�ǖ�(���ψČ�CR�����)
     */
    public String getEstSTKYKNM() {
        return (String) get("ESTSTKYKNM");
    }

    /**
     * �ݒ�ǖ�(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �ݒ�ǖ�(���ψČ�CR�����)
     */
    public void setEstSTKYKNM(String val) {
        set("ESTSTKYKNM", val);
    }

    /**
     * �c���`�F�b�N(�����捞)���擾����
     *
     * @return �c���`�F�b�N(�����捞)
     */
    public String getCptEGTYKFLG() {
        return (String) get(Tbj22SeisakuhiSs.EGTYKFLG);
    }

    /**
     * �c���`�F�b�N(�����捞)��ݒ肷��
     *
     * @param val �c���`�F�b�N(�����捞)
     */
    public void setCptEGTYKFLG(String val) {
        set(Tbj22SeisakuhiSs.EGTYKFLG, val);
    }

    /**
     * �c���`�F�b�N(���ψČ�CR�����)���擾����
     *
     * @return �c���`�F�b�N(���ψČ�CR�����)
     */
    public String getEstEGTYKFLG() {
        return (String) get(Tbj07EstimateCreate.EGTYKFLG);
    }

    /**
     * �c���`�F�b�N(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �c���`�F�b�N(���ψČ�CR�����)
     */
    public void setEstEGTYKFLG(String val) {
        set(Tbj07EstimateCreate.EGTYKFLG, val);
    }

    /**
     * ���͒S���R�[�h(�����捞)���擾����
     *
     * @return ���͒S���R�[�h(�����捞)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCptINPUTTNTCD() {
        return (BigDecimal) get(Tbj22SeisakuhiSs.INPUTTNTCD);
    }

    /**
     * ���͒S���R�[�h(�����捞)��ݒ肷��
     *
     * @param val ���͒S���R�[�h(�����捞)
     */
    public void setCptINPUTTNTCD(BigDecimal val) {
        set(Tbj22SeisakuhiSs.INPUTTNTCD, val);
    }

    /**
     * ���͒S���R�[�h(���ψČ�CR�����)���擾����
     *
     * @return ���͒S���R�[�h(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstINPUTTNTCD() {
        return (BigDecimal) get(Tbj07EstimateCreate.INPUTTNTCD);
    }

    /**
     * ���͒S���R�[�h(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���͒S���R�[�h(���ψČ�CR�����)
     */
    public void setEstINPUTTNTCD(BigDecimal val) {
        set(Tbj07EstimateCreate.INPUTTNTCD, val);
    }

    /**
     * ���͒S���Җ�(�����捞)���擾����
     *
     * @return ���͒S���Җ�(�����捞)
     */
    public String getCptINPUTTNTNM() {
        return (String) get("CPTINPUTTNT");
    }

    /**
     * ���͒S���Җ�(�����捞)��ݒ肷��
     *
     * @param val ���͒S���Җ�(�����捞)
     */
    public void setCptINPUTTNTNM(String val) {
        set("CPTINPUTTNT", val);
    }

    /**
     * ���͒S���Җ�(���ψČ�CR�����)���擾����
     *
     * @return ���͒S���Җ�(���ψČ�CR�����)
     */
    public String getEstINPUTTNTNM() {
        return (String) get("ESTINPUTTNT");
    }

    /**
     * ���͒S���Җ�(���ψČ�CR�����)��ݒ肷��
     *
     * @param val ���͒S���Җ�(���ψČ�CR�����)
     */
    public void setEstINPUTTNTNM(String val) {
        set("ESTINPUTTNT", val);
    }

}
