package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;

import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.tbl.Tbj07EstimateCreate;
import jp.co.isid.ham.integ.tbl.Tbj11CrCreateData;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HC���ψꗗ�ύX�m�F(�����)�f�[�^�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/3/21 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCEstimateListDiffTotalVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHCEstimateListDiffTotalVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHCEstimateListDiffTotalVO();
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
        return (BigDecimal) get(Tbj11CrCreateData.SEQUENCENO);
    }

    /**
     * �����Ǘ�NO��ݒ肷��
     *
     * @param val �����Ǘ�NO
     */
    public void setSEQUENCENO(BigDecimal val) {
        set(Tbj11CrCreateData.SEQUENCENO, val);
    }

    /**
     * �d�ʎԎ�R�[�h(CR�����Ǘ�)���擾����
     *
     * @return �d�ʎԎ�R�[�h(CR�����Ǘ�)
     */
    public String getCrDCARCD() {
        return (String) get(Tbj11CrCreateData.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �d�ʎԎ�R�[�h(CR�����Ǘ�)
     */
    public void setCrDCARCD(String val) {
        set(Tbj11CrCreateData.DCARCD, val);
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
     * �N��(CR�����Ǘ�)���擾����
     *
     * @return �N��(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrCRDATE() {
        return (Date) get(Tbj11CrCreateData.CRDATE);
    }

    /**
     * �N��(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �N��(CR�����Ǘ�)
     */
    public void setCrCRDATE(Date val) {
        set(Tbj11CrCreateData.CRDATE, val);
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
     * ��ʔ��f�t���O(CR�����Ǘ�)���擾����
     *
     * @return ��ʔ��f�t���O(CR�����Ǘ�)
     */
    public String getCrCLASSDIV() {
        return (String) get(Tbj11CrCreateData.CLASSDIV);
    }

    /**
     * ��ʔ��f�t���O(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ��ʔ��f�t���O(CR�����Ǘ�)
     */
    public void setCrCLASSDIV(String val) {
        set(Tbj11CrCreateData.CLASSDIV, val);
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
     * �\�Z���ރR�[�h(CR�����Ǘ�)���擾����
     *
     * @return �\�Z���ރR�[�h(CR�����Ǘ�)
     */
    public String getCrCLASSCD() {
        return (String) get(Tbj11CrCreateData.CLASSCD);
    }

    /**
     * �\�Z���ރR�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �\�Z���ރR�[�h(CR�����Ǘ�)
     */
    public void setCrCLASSCD(String val) {
        set(Tbj11CrCreateData.CLASSCD, val);
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
     * �\�Z�\��ڃR�[�h(CR�����Ǘ�)���擾����
     *
     * @return �\�Z�\��ڃR�[�h
     */
    public String getCrEXPCD() {
        return (String) get(Tbj11CrCreateData.EXPCD);
    }

    /**
     * �\�Z�\��ڃR�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �\�Z�\��ڃR�[�h
     */
    public void setCrEXPCD(String val) {
        set(Tbj11CrCreateData.EXPCD, val);
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
     * ���(CR�����Ǘ�)���擾����
     *
     * @return ���(CR�����Ǘ�)
     */
    public String getCrEXPENSE() {
        return (String) get(Tbj11CrCreateData.EXPENSE);
    }

    /**
     * ���(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���(CR�����Ǘ�)
     */
    public void setCrEXPENSE(String val) {
        set(Tbj11CrCreateData.EXPENSE, val);
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
     * �����z(CR�����Ǘ�)���擾����
     *
     * @return �����z(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrGETMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.GETMONEY);
    }

    /**
     * �����z(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���ϋ��z(CR�����Ǘ�)
     */
    public void setCrGETMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.GETMONEY, val);
    }

    /**
     * �����z(���ψČ�CR�����)���擾����
     *
     * @return �����z(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstGETMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.GETMONEY);
    }

    /**
     * �����z(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �����z(���ψČ�CR�����)
     */
    public void setEstGETMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.GETMONEY, val);
    }

    /**
     * �����z�m�F(CR�����Ǘ�)���擾����
     *
     * @return �����z�m�F(CR�����Ǘ�)
     */
    public String getCrGETCONF() {
        return (String) get(Tbj11CrCreateData.GETCONF);
    }

    /**
     * �����z�m�F(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���ϋ��z�m�F(CR�����Ǘ�)
     */
    public void setCrGETCONF(String val) {
        set(Tbj11CrCreateData.GETCONF, val);
    }

    /**
     * �����z�m�F(���ψČ�CR�����)���擾����
     *
     * @return �����z�m�F(���ψČ�CR�����)
     */
    public String getEstGETCONF() {
        return (String) get(Tbj07EstimateCreate.GETCONF);
    }

    /**
     * �����z�m�F(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �����z�m�F(���ψČ�CR�����)
     */
    public void setEstGETCONF(String val) {
        set(Tbj07EstimateCreate.GETCONF, val);
    }

    /**
     * �������z(CR�����Ǘ�)���擾����
     *
     * @return �������z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrPAYMONEY() {
        return (BigDecimal) get(Tbj11CrCreateData.PAYMONEY);
    }

    /**
     * �������z(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �������z
     */
    public void setCrPAYMONEY(BigDecimal val) {
        set(Tbj11CrCreateData.PAYMONEY, val);
    }

    /**
     * �������z(���ψČ�CR�����)���擾����
     *
     * @return �������z(���ψČ�CR�����)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getEstPAYMONEY() {
        return (BigDecimal) get(Tbj07EstimateCreate.PAYMONEY);
    }

    /**
     * �������z(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �������z(���ψČ�CR�����)
     */
    public void setEstPAYMONEY(BigDecimal val) {
        set(Tbj07EstimateCreate.PAYMONEY, val);
    }

    /**
     * �������z�m�F(CR�����Ǘ�)���擾����
     *
     * @return �������z�m�F
     */
    public String getCrPAYCONF() {
        return (String) get(Tbj11CrCreateData.PAYCONF);
    }

    /**
     * �������z�m�F(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �������z�m�F
     */
    public void setCrPAYCONF(String val) {
        set(Tbj11CrCreateData.PAYCONF, val);
    }

    /**
     * �������z�m�F(���ψČ�CR�����)���擾����
     *
     * @return �������z�m�F(���ψČ�CR�����)
     */
    public String getEstPAYCONF() {
        return (String) get(Tbj07EstimateCreate.PAYCONF);
    }

    /**
     * �������z�m�F(���ψČ�CR�����)��ݒ肷��
     *
     * @param val �������z�m�F(���ψČ�CR�����)
     */
    public void setEstPAYCONF(String val) {
        set(Tbj07EstimateCreate.PAYCONF, val);
    }

    /**
     * �敪�R�[�h(CR�����Ǘ�)���擾����
     *
     * @return �敪�R�[�h(CR�����Ǘ�)
     */
    public String getCrDIVCD() {
        return (String) get(Tbj11CrCreateData.DIVCD);
    }

    /**
     * �敪�R�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �敪�R�[�h(CR�����Ǘ�)
     */
    public void setCrDIVCD(String val) {
        set(Tbj11CrCreateData.DIVCD, val);
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
     * �O���[�v�R�[�h(CR�����Ǘ�)���擾����
     *
     * @return �O���[�v�R�[�h(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrGROUPCD() {
        return (BigDecimal) get(Tbj11CrCreateData.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �O���[�v�R�[�h(CR�����Ǘ�)
     */
    public void setCrGROUPCD(BigDecimal val) {
        set(Tbj11CrCreateData.GROUPCD, val);
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
     * ���ԊJ�n(CR�����Ǘ�)���擾����
     *
     * @return ���ԊJ�n(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrKIKANS() {
        return (Date) get(Tbj11CrCreateData.KIKANS);
    }

    /**
     * ���ԊJ�n(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���ԊJ�n(CR�����Ǘ�)
     */
    public void setCrKIKANS(Date val) {
        set(Tbj11CrCreateData.KIKANS, val);
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
     * ���ԏI��(CR�����Ǘ�)���擾����
     *
     * @return ���ԏI��(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrKIKANE() {
        return (Date) get(Tbj11CrCreateData.KIKANE);
    }

    /**
     * ���ԏI��(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���ԏI��(CR�����Ǘ�)
     */
    public void setCrKIKANE(Date val) {
        set(Tbj11CrCreateData.KIKANE, val);
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
     * �x����[�i��(CR�����Ǘ�)���擾����
     *
     * @return �x����[�i��(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrDELIVERDAY() {
        return (Date) get(Tbj11CrCreateData.DELIVERDAY);
    }

    /**
     * �x����[�i��(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �x����[�i��(CR�����Ǘ�)
     */
    public void setCrDELIVERDAY(Date val) {
        set(Tbj11CrCreateData.DELIVERDAY, val);
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
     * �ݒ茎(CR�����Ǘ�)���擾����
     *
     * @return �ݒ茎(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public Date getCrSETMONTH() {
        return (Date) get(Tbj11CrCreateData.SETMONTH);
    }

    /**
     * �ݒ茎(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �ݒ茎(CR�����Ǘ�)
     */
    public void setCrSETMONTH(Date val) {
        set(Tbj11CrCreateData.SETMONTH, val);
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
     * �ݒ�ǃi���o�[(CR�����Ǘ�)���擾����
     *
     * @return �ݒ�ǃi���o�[(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrSTKYKNO() {
        return (BigDecimal) get(Tbj11CrCreateData.STKYKNO);
    }

    /**
     * �ݒ�ǃi���o�[(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �ݒ�ǃi���o�[(CR�����Ǘ�)
     */
    public void setCrSTKYKNO(BigDecimal val) {
        set(Tbj11CrCreateData.STKYKNO, val);
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
     * �ݒ�ǖ�(CR�����Ǘ�)���擾����
     *
     * @return �ݒ�ǖ�(CR�����Ǘ�)
     */
    public String getCrSTKYKNM() {
        return (String) get("CRSTKYKNM");
    }

    /**
     * �ݒ�ǖ�(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �ݒ�ǖ�(CR�����Ǘ�)
     */
    public void setCrSTKYKNM(String val) {
        set("CRSTKYKNM", val);
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
     * �c���`�F�b�N(CR�����Ǘ�)���擾����
     *
     * @return �c���`�F�b�N(CR�����Ǘ�)
     */
    public String getCrEGTYKFLG() {
        return (String) get(Tbj11CrCreateData.EGTYKFLG);
    }

    /**
     * �c���`�F�b�N(CR�����Ǘ�)��ݒ肷��
     *
     * @param val �c���`�F�b�N(CR�����Ǘ�)
     */
    public void setCrEGTYKFLG(String val) {
        set(Tbj11CrCreateData.EGTYKFLG, val);
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
     * ���͒S���R�[�h(CR�����Ǘ�)���擾����
     *
     * @return ���͒S���R�[�h(CR�����Ǘ�)
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getCrINPUTTNTCD() {
        return (BigDecimal) get(Tbj11CrCreateData.INPUTTNTCD);
    }

    /**
     * ���͒S���R�[�h(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���͒S���R�[�h(CR�����Ǘ�)
     */
    public void setCrINPUTTNTCD(BigDecimal val) {
        set(Tbj11CrCreateData.INPUTTNTCD, val);
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
     * ���͒S���Җ�(CR�����Ǘ�)���擾����
     *
     * @return ���͒S���Җ�(CR�����Ǘ�)
     */
    public String getCrINPUTTNTNM() {
        return (String) get("CRINPUTTNT");
    }

    /**
     * ���͒S���Җ�(CR�����Ǘ�)��ݒ肷��
     *
     * @param val ���͒S���Җ�(CR�����Ǘ�)
     */
    public void setCrINPUTTNTNM(String val) {
        set("CRINPUTTNT", val);
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
