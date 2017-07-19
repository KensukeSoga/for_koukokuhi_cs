package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM������(���ϖ���)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMBillDetailVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �� */
    public static final String TAX = "TAX";

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMBillDetailVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMBillDetailVO();
    }

    /**
     * ���ϖ��׊Ǘ�NO���擾����
     * @return BigDecimal ���ϖ��׊Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTDETAILSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTDETAILSEQNO);
    }

    /**
     * ���ϖ��׊Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ϖ��׊Ǘ�NO
     */
    public void setESTDETAILSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTDETAILSEQNO, val);
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
     * ���ψČ��Ǘ�NO���擾����
     * @return BigDecimal ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ψČ��Ǘ�NO
     */
    public void setESTSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.ESTSEQNO, val);
    }

    /**
     * �\�[�g�����擾����
     * @return BigDecimal �\�[�g��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSORTNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.SORTNO);
    }

    /**
     * �\�[�g����ݒ肷��
     * @param val BigDecimal �\�[�g��
     */
    public void setSORTNO(BigDecimal val) {
        set(Tbj06EstimateDetail.SORTNO, val);
    }

    /**
     * ���i�R�[�h���擾����
     * @return String ���i�R�[�h
     */
    public String getPRODUCTCD() {
        return (String) get(Tbj06EstimateDetail.PRODUCTCD);
    }

    /**
     * ���i�R�[�h��ݒ肷��
     * @param val String ���i�R�[�h
     */
    public void setPRODUCTCD(String val) {
        set(Tbj06EstimateDetail.PRODUCTCD, val);
    }

    /**
     * ���i�����擾����
     * @return String ���i��
     */
    public String getPRODUCTNM() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNM);
    }

    /**
     * ���i����ݒ肷��
     * @param val String ���i��
     */
    public void setPRODUCTNM(String val) {
        set(Tbj06EstimateDetail.PRODUCTNM, val);
    }

    /**
     * ���i��(�T�u)���擾����
     * @return String ���i��(�T�u�j
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * ���i��(�T�u)��ݒ肷��
     * @param val String ���i��(�T�u)
     */
    public void setPRODUCTNMSUB(String val) {
        set(Tbj06EstimateDetail.PRODUCTNMSUB, val);
    }

    /**
     * �}�̕��ރR�[�h���擾����
     * @return String �}�̕��ރR�[�h
     */
    public String getMEDIACLASSCD() {
        return (String) get(Tbj06EstimateDetail.MEDIACLASSCD);
    }

    /**
     * �}�̕��ރR�[�h��ݒ肷��
     * @param val String �}�̕��ރR�[�h
     */
    public void setMEDIACLASSCD(String val) {
        set(Tbj06EstimateDetail.MEDIACLASSCD, val);
    }

    /**
     * �}�̃R�[�h���擾����
     * @return String �}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj06EstimateDetail.MEDIACD);
    }

    /**
     * �}�̃R�[�h��ݒ肷��
     * @param val String �}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj06EstimateDetail.MEDIACD, val);
    }

    /**
     * �Ɩ����ރR�[�h���擾����
     * @return String �Ɩ����ރR�[�h
     */
    public String getBUSINESSCLASSCD() {
        return (String) get(Tbj06EstimateDetail.BUSINESSCLASSCD);
    }

    /**
     * �Ɩ����ރR�[�h��ݒ肷��
     * @param val String �Ɩ����ރR�[�h
     */
    public void setBUSINESSCLASSCD(String val) {
        set(Tbj06EstimateDetail.BUSINESSCLASSCD, val);
    }

    /**
     * �Ɩ��R�[�h���擾����
     * @return String �Ɩ��R�[�h
     */
    public String getBUSINESSCD() {
        return (String) get(Tbj06EstimateDetail.BUSINESSCD);
    }

    /**
     * �Ɩ��R�[�h��ݒ肷��
     * @param val String �Ɩ��R�[�h
     */
    public void setBUSINESSCD(String val) {
        set(Tbj06EstimateDetail.BUSINESSCD, val);
    }

    /**
     * �E�v���擾����
     * @return String �E�v
     */
    public String getTEKIYOU() {
        return (String) get(Tbj06EstimateDetail.TEKIYOU);
    }

    /**
     * �E�v��ݒ肷��
     * @param val String �E�v
     */
    public void setTEKIYOU(String val) {
        set(Tbj06EstimateDetail.TEKIYOU, val);
    }

    /**
     * ���{�����擾����
     * @return Date ���{��
     */
    @XmlElement(required = true, nillable = true)
    public Date getOPERATIONDATE() {
        return (Date) get(Tbj06EstimateDetail.OPERATIONDATE);
    }

    /**
     * ���{����ݒ肷��
     * @param val Date ���{��
     */
    public void setOPERATIONDATE(Date val) {
        set(Tbj06EstimateDetail.OPERATIONDATE, val);
    }

    /**
     * �T�C�Y�R�[�h���擾����
     * @return String �T�C�Y�R�[�h
     */
    public String getSIZECD() {
        return (String) get(Tbj06EstimateDetail.SIZECD);
    }

    /**
     * �T�C�Y�R�[�h��ݒ肷��
     * @param val String �T�C�Y�R�[�h
     */
    public void setSIZECD(String val) {
        set(Tbj06EstimateDetail.SIZECD, val);
    }

    /**
     * �T�C�Y���擾����
     * @return String �T�C�Y
     */
    public String getSIZE() {
        return (String) get(Tbj06EstimateDetail.SIZE);
    }

    /**
     * �T�C�Y��ݒ肷��
     * @param val String �T�C�Y
     */
    public void setSIZE(String val) {
        set(Tbj06EstimateDetail.SIZE, val);
    }

    /**
     * ���ʂ��擾����
     * @return BigDecimal ����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSUURYOU() {
        return (BigDecimal) get(Tbj06EstimateDetail.SUURYOU);
    }

    /**
     * ���ʂ�ݒ肷��
     * @param val BigDecimal ����
     */
    public void setSUURYOU(BigDecimal val) {
        set(Tbj06EstimateDetail.SUURYOU, val);
    }

    /**
     * �P�ʃO���[�v�R�[�h���擾����
     * @return String �P�ʃO���[�v�R�[�h
     */
    public String getUNITGROUPCD() {
        return (String) get(Tbj06EstimateDetail.UNITGROUPCD);
    }

    /**
     * �P�ʃO���[�v�R�[�h��ݒ肷��
     * @param val String �P�ʃO���[�v�R�[�h
     */
    public void setUNITGROUPCD(String val) {
        set(Tbj06EstimateDetail.UNITGROUPCD, val);
    }

    /**
     * �P�ʃO���[�v�����擾����
     * @return String �P�ʃO���[�v��
     */
    public String getUNITGROUPNM() {
        return (String) get(Tbj06EstimateDetail.UNITGROUPNM);
    }

    /**
     * �P�ʃO���[�v����ݒ肷��
     * @param val String �P�ʃO���[�v��
     */
    public void setUNITGROUPNM(String val) {
        set(Tbj06EstimateDetail.UNITGROUPNM, val);
    }

    /**
     * �P�����擾����
     * @return BigDecimal �P��
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getTANKA() {
        return (BigDecimal) get(Tbj06EstimateDetail.TANKA);
    }

    /**
     * �P����ݒ肷��
     * @param val BigDecimal �P��
     */
    public void setTANKA(BigDecimal val) {
        set(Tbj06EstimateDetail.TANKA, val);
    }

    /**
     * �W�����z���擾����
     * @return BigDecimal �W�����z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getHYOUJUN() {
        return (BigDecimal) get(Tbj06EstimateDetail.HYOUJUN);
    }

    /**
     * �W�����z��ݒ肷��
     * @param val BigDecimal �W�����z
     */
    public void setHYOUJUN(BigDecimal val) {
        set(Tbj06EstimateDetail.HYOUJUN, val);
    }

    /**
     * �l���z���擾����
     * @return BigDecimal �l���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getNEBIKI() {
        return (BigDecimal) get(Tbj06EstimateDetail.NEBIKI);
    }

    /**
     * �l���z��ݒ肷��
     * @param val BigDecimal �l���z
     */
    public void setNEBIKI(BigDecimal val) {
        set(Tbj06EstimateDetail.NEBIKI, val);
    }

    /**
     * ���ϋ��z���擾����
     * @return BigDecimal ���ϋ��z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getMITUMORI() {
        return (BigDecimal) get(Tbj06EstimateDetail.MITUMORI);
    }

    /**
     * ���ϋ��z��ݒ肷��
     * @param val BigDecimal ���ϋ��z
     */
    public void setMITUMORI(BigDecimal val) {
        set(Tbj06EstimateDetail.MITUMORI, val);
    }

    /**
     * �ېőΏۊz���擾����
     *
     * @return BigDecimal �ېőΏۊz
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getKAZEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.KAZEI);
    }

    /**
     * �ېőΏۊz��ݒ肷��
     * @param val BigDecimal �ېőΏۊz
     */
    public void setKAZEI(BigDecimal val) {
        set(Tbj06EstimateDetail.KAZEI, val);
    }

    /**
     * ����Ŋz���擾����
     * @return BigDecimal ����Ŋz
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getSYOUHIZEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.SYOUHIZEI);
    }

    /**
     * ����Ŋz��ݒ肷��
     * @param val BigDecimal ����Ŋz
     */
    public void setSYOUHIZEI(BigDecimal val) {
        set(Tbj06EstimateDetail.SYOUHIZEI, val);
    }

    /**
     * ���v���z���擾����
     * @return BigDecimal ���v���z
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getGOUKEI() {
        return (BigDecimal) get(Tbj06EstimateDetail.GOUKEI);
    }

    /**
     * ���v���z��ݒ肷��
     * @param val BigDecimal ���v���z
     */
    public void setGOUKEI(BigDecimal val) {
        set(Tbj06EstimateDetail.GOUKEI, val);
    }

    /**
     * �d������Ōv�Z�敪���擾����
     * @return String �d������Ōv�Z�敪
     */
    public String getCALKBN() {
        return (String) get(Tbj06EstimateDetail.CALKBN);
    }

    /**
     * �d������Ōv�Z�敪��ݒ肷��
     * @param val String �d������Ōv�Z�敪
     */
    public void setCALKBN(String val) {
        set(Tbj06EstimateDetail.CALKBN, val);
    }

    /**
     * �[���t���O���擾����
     * @return String �[���t���O
     */
    public String getNOUNYUUFLG() {
        return (String) get(Tbj06EstimateDetail.NOUNYUUFLG);
    }

    /**
     * �[���t���O��ݒ肷��
     * @param val String �[���t���O
     */
    public void setNOUNYUUFLG(String val) {
        set(Tbj06EstimateDetail.NOUNYUUFLG, val);
    }

    /**
     * �o�����t���O���擾����
     * @return String �o�����t���O
     */
    public String getDEKIDAKAFLG() {
        return (String) get(Tbj06EstimateDetail.DEKIDAKAFLG);
    }

    /**
     * �o�����t���O��ݒ肷��
     * @param val String �o�����t���O
     */
    public void setDEKIDAKAFLG(String val) {
        set(Tbj06EstimateDetail.DEKIDAKAFLG, val);
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
     * @param val BigDecimal ������O���[�v�o�͏�SEQNO
     */
    public void setHCBUMONCDBILLSEQNO(BigDecimal val) {
        set(Tbj06EstimateDetail.HCBUMONCDBILLSEQNO, val);
    }

    /**
     * �f�[�^�쐬�������擾����
     * @return Date �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj06EstimateDetail.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     * @param val Date �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj06EstimateDetail.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     * @return String �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj06EstimateDetail.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     * @param val String �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj06EstimateDetail.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     * @return String �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj06EstimateDetail.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     * @param val String �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj06EstimateDetail.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     * @return String �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj06EstimateDetail.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     * @param val String �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj06EstimateDetail.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     * @return Date �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj06EstimateDetail.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     * @param val Date �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj06EstimateDetail.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     * @return String �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj06EstimateDetail.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     * @param val String �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj06EstimateDetail.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     * @return String �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj06EstimateDetail.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     * @param val String �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj06EstimateDetail.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     * @return String �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj06EstimateDetail.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     * @param val String �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj06EstimateDetail.UPDID, val);
    }

    /**
     * �}�̕��ޖ����擾����
     * @return String �}�̕��ޖ�
     */
    public String getMEDIACLASSNM() {
        return (String) get(Mbj08HcProduct.MEDIACLASSNM);
    }

    /**
     * �}�̕��ޖ���ݒ肷��
     * @param val String �}�̕��ޖ�
     */
    public void setMEDIACLASSNM(String val) {
        set(Mbj08HcProduct.MEDIACLASSNM, val);
    }

    /**
     * �}�̖����擾����
     * @return String �}�̖�
     */
    public String getMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * �}�̖���ݒ肷��
     * @param val String �}�̖�
     */
    public void setMEDIANM(String val) {
        set(Mbj08HcProduct.MEDIANM, val);
    }

    /**
     * �Ɩ����ޖ����擾����
     * @return String �Ɩ����ޖ�
     */
    public String getBUSINESSCLASSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSCLASSNM);
    }

    /**
     * �Ɩ����ޖ���ݒ肷��
     * @param val String �Ɩ����ޖ�
     */
    public void setBUSINESSCLASSNM(String val) {
        set(Mbj08HcProduct.BUSINESSCLASSNM, val);
    }

    /**
     * �Ɩ������擾����
     * @return String �Ɩ���
     */
    public String getBUSINESSNM() {
        return (String) get(Mbj08HcProduct.BUSINESSNM);
    }

    /**
     * �Ɩ�����ݒ肷��
     * @param val String �Ɩ���
     */
    public void setBUSINESSNM(String val) {
        set(Mbj08HcProduct.BUSINESSNM, val);
    }

    /**
     * ���i�����擾����
     * @return String ���i��
     */
    public String getMstrPRODUCTNM() {
        return (String) get(Mbj08HcProduct.PRODUCTNM);
    }

    /**
     * ���i����ݒ肷��
     * @param val String ���i��
     */
    public void setMstrPRODUCTNM(String val) {
        set(Mbj08HcProduct.PRODUCTNM, val);
    }

    /**
     * �ł��擾����
     * @return String ��
     */
    public String getTAX() {
        return (String) get(TAX);
    }

    /**
     * �ł�ݒ肷��
     * @param val String ��
     */
    public void setTAX(String val) {
        set(TAX, val);
    }

}
