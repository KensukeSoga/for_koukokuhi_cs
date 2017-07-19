package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj09Hiyou;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * HM���Ϗ��A�������쐬(�}��)�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * �E�����Ɩ��ύX�Ή�(2016/01/27 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class FindHMEstimateMediaReportVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindHMEstimateMediaReportVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    @Override
    public Object newInstance() {
        return new FindHMEstimateMediaReportVO();
    }

    /**
     * �t�F�C�Y���擾����
     * @return BigDecimal �t�F�C�Y
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getItemPHASE() {
        return (BigDecimal) get(Tbj05EstimateItem.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setItemPHASE(BigDecimal val) {
        set(Tbj05EstimateItem.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getItemCRDATE() {
        return (Date) get(Tbj05EstimateItem.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val �N��
     */
    public void setItemCRDATE(Date val) {
        set(Tbj05EstimateItem.CRDATE, val);
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     * @return BigDecimal ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getItemESTSEQNO() {
        return (BigDecimal) get(Tbj05EstimateItem.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ψČ��Ǘ�NO
     */
    public void setItemESTSEQNO(BigDecimal val) {
        set(Tbj05EstimateItem.ESTSEQNO, val);
    }

    /**
     * ���ώ�ʂ��擾����
     * @return String ���ώ��
     */
    public String getESTIMATECLASS() {
        return (String) get(Tbj05EstimateItem.ESTIMATECLASS);
    }

    /**
     * ���ώ�ʂ�ݒ肷��
     * @param val String ���ώ��
     */
    public void setESTIMATECLASS(String val) {
        set(Tbj05EstimateItem.ESTIMATECLASS, val);
    }

    /**
     * ���ϓ��t���擾����
     * @return Date ���ϓ��t
     */
    @XmlElement(required = true, nillable = true)
    public Date getESTIMATEDATE() {
        return (Date) get(Tbj05EstimateItem.ESTIMATEDATE);
    }

    /**
     * ���ϓ��t��ݒ肷��
     * @param val Date ���ϓ��t
     */
    public void setESTIMATEDATE(Date val) {
        set(Tbj05EstimateItem.ESTIMATEDATE, val);
    }

    /**
     * �R�[�v�敪���擾����
     * @return String �R�[�v�敪
     */
    public String getCOOPKBN() {
        return (String) get(Tbj05EstimateItem.COOPKBN);
    }

    /**
     * �R�[�v�敪��ݒ肷��
     * @param val String �R�[�v�敪
     */
    public void setCOOPKBN(String val) {
        set(Tbj05EstimateItem.COOPKBN, val);
    }

    /**
     * ������擾����
     * @return String ����
     */
    public String getADDRESS() {
        return (String) get(Tbj05EstimateItem.ADDRESS);
    }

    /**
     * �����ݒ肷��
     * @param val String ����
     */
    public void setADDRESS(String val) {
        set(Tbj05EstimateItem.ADDRESS, val);
    }

    /**
     * �Č������擾����
     * @return String �Č���
     */
    public String getESTIMATENM() {
        return (String) get(Tbj05EstimateItem.ESTIMATENM);
    }

    /**
     * �Č�����ݒ肷��
     * @param val String �Č���
     */
    public void setESTIMATENM(String val) {
        set(Tbj05EstimateItem.ESTIMATENM, val);
    }

    /**
     * HC����R�[�h���擾����
     * @return String HC����R�[�h
     */
    public String getHCBUMONCD() {
        return (String) get(Tbj05EstimateItem.HCBUMONCD);
    }

    /**
     * HC����R�[�h��ݒ肷��
     * @param val String HC����R�[�h
     */
    public void setHCBUMONCD(String val) {
        set(Tbj05EstimateItem.HCBUMONCD, val);
    }

    /**
     * HC�S���Җ����擾����
     * @return String HC�S���Җ�
     */
    public String getHCUSERNM() {
        return (String) get(Tbj05EstimateItem.HCUSERNM);
    }

    /**
     * HC�S���Җ���ݒ肷��
     * @param val String HC�S���Җ�
     */
    public void setHCUSERNM(String val) {
        set(Tbj05EstimateItem.HCUSERNM, val);
    }

    /**
     * �[�i�������擾����
     * @return Date �[�i����
     */
    @XmlElement(required = true, nillable = true)
    public Date getDLVDATE() {
        return (Date) get(Tbj05EstimateItem.DLVDATE);
    }

    /**
     * �[�i������ݒ肷��
     * @param val Date �[�i����
     */
    public void setDLVDATE(Date val) {
        set(Tbj05EstimateItem.DLVDATE, val);
    }

    /**
     * �l�������擾����
     * @return BigDecimal �l����
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDISCOUNTRATE() {
        return (BigDecimal) get(Tbj05EstimateItem.DISCOUNTRATE);
    }

    /**
     * �l������ݒ肷��
     * @param val BigDecimal �l����
     */
    public void setDISCOUNTRATE(BigDecimal val) {
        set(Tbj05EstimateItem.DISCOUNTRATE, val);
    }

    /**
     * ���l���擾����
     * @return String ���l
     */
    public String getBIKO() {
        return (String) get(Tbj05EstimateItem.BIKO);
    }

    /**
     * ���l��ݒ肷��
     * @param val String ���l
     */
    public void setBIKO(String val) {
        set(Tbj05EstimateItem.BIKO, val);
    }

    /**
     * �ŏI���Ϗo�͓������擾����
     * @return Date �ŏI���Ϗo�͓���
     */
    @XmlElement(required = true, nillable = true)
    public Date getLASTOUTPUTDATE() {
        return (Date) get(Tbj05EstimateItem.LASTOUTPUTDATE);
    }

    /**
     * �ŏI���Ϗo�͓�����ݒ肷��
     * @param val Date �ŏI���Ϗo�͓���
     */
    public void setLASTOUTPUTDATE(Date val) {
        set(Tbj05EstimateItem.LASTOUTPUTDATE, val);
    }

    /**
     * �ŏI���Ϗo�͒S���҂��擾����
     * @return String �ŏI���Ϗo�͒S����
     */
    public String getLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.LASTOUTPUTNM);
    }

    /**
     * �ŏI���Ϗo�͒S���҂�ݒ肷��
     * @param val String �ŏI���Ϗo�͒S����
     */
    public void setLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.LASTOUTPUTNM, val);
    }

    /**
     * ���Ϗo�̓t�@�C�������擾����
     * @return String �o�̓t�@�C����
     */
    public String getOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.OUTPUTFILENM);
    }

    /**
     * ���Ϗo�̓t�@�C������ݒ肷��
     * @param val String �o�̓t�@�C����
     */
    public void setOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.OUTPUTFILENM, val);
    }

    /**
     * �������׏��ŏI�o�͓������擾����
     * @return String �������׏��ŏI�o�͓���
     */
    public String getBILLDTLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE);
    }

    /**
     * �������׏��ŏI�o�͓�����ݒ肷��
     * @param val String �������׏��ŏI�o�͓���
     */
    public void setBILLDTLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLDTLLASTOUTPUTDATE, val);
    }

    /**
     * �������׏��ŏI�o�͒S���҂��擾����
     * @return String �������׏��ŏI�o�͒S����
     */
    public String getBILLDTLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLDTLLASTOUTPUTNM);
    }

    /**
     * �������׏��ŏI�o�͒S���҂�ݒ肷��
     * @param val String �������׏��ŏI�o�͒S����
     */
    public void setBILLDTLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLDTLLASTOUTPUTNM, val);
    }

    /**
     * �������׏��o�̓t�@�C�������擾����
     * @return String �������׏��o�̓t�@�C����
     */
    public String getBILLDTLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLDTLOUTPUTFILENM);
    }

    /**
     * �������׏��o�̓t�@�C������ݒ肷��
     * @param val String �������׏��o�̓t�@�C����
     */
    public void setBILLDTLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLDTLOUTPUTFILENM, val);
    }

    /**
     * �������ŏI�o�͓������擾����
     * @return String �������ŏI�o�͓���
     */
    public String getBILLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLLASTOUTPUTDATE);
    }

    /**
     * �������ŏI�o�͓�����ݒ肷��
     * @param val String �������ŏI�o�͓���
     */
    public void setBILLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLLASTOUTPUTDATE, val);
    }

    /**
     * �������ŏI�o�͒S���҂��擾����
     * @return String �������ŏI�o�͒S����
     */
    public String getBILLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLLASTOUTPUTNM);
    }

    /**
     * �������ŏI�o�͒S���҂�ݒ肷��
     * @param val String �������ŏI�o�͒S����
     */
    public void setBILLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLLASTOUTPUTNM, val);
    }

    /**
     * �������o�̓t�@�C�������擾����
     * @return String �������o�̓t�@�C����
     */
    public String getBILLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLOUTPUTFILENM);
    }

    /**
     * �������o�̓t�@�C������ݒ肷��
     * @param val String �������o�̓t�@�C����
     */
    public void setBILLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLOUTPUTFILENM, val);
    }

    /**
     * �����f�[�^Excel�t�@�C���ŏI�o�͓������擾����
     * @return String �����f�[�^Excel�t�@�C���ŏI�o�͓���
     */
    public String getBILLEXLLASTOUTPUTDATE() {
        return (String) get(Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE);
    }

    /**
     * �����f�[�^Excel�t�@�C���ŏI�o�͓�����ݒ肷��
     * @param val String �����f�[�^Excel�t�@�C���ŏI�o�͓���
     */
    public void setBILLEXLLASTOUTPUTDATE(String val) {
        set(Tbj05EstimateItem.BILLEXLLASTOUTPUTDATE, val);
    }

    /**
     * �����f�[�^Excel�t�@�C���ŏI�o�͒S���҂��擾����
     * @return String �����f�[�^Excel�t�@�C���ŏI�o�͒S����
     */
    public String getBILLEXLLASTOUTPUTNM() {
        return (String) get(Tbj05EstimateItem.BILLEXLLASTOUTPUTNM);
    }

    /**
     * �����f�[�^Excel�t�@�C���ŏI�o�͒S���҂�ݒ肷��
     * @param val String �����f�[�^Excel�t�@�C���ŏI�o�͒S����
     */
    public void setBILLEXLLASTOUTPUTNM(String val) {
        set(Tbj05EstimateItem.BILLEXLLASTOUTPUTNM, val);
    }

    /**
     * �����f�[�^�o��Excel�t�@�C�������擾����
     * @return String �����f�[�^�o��Excel�t�@�C����
     */
    public String getBILLEXLOUTPUTFILENM() {
        return (String) get(Tbj05EstimateItem.BILLEXLOUTPUTFILENM);
    }

    /**
     * �����f�[�^�o��Excel�t�@�C������ݒ肷��
     * @param val String �����f�[�^�o��Excel�t�@�C����
     */
    public void setBILLEXLOUTPUTFILENM(String val) {
        set(Tbj05EstimateItem.BILLEXLOUTPUTFILENM, val);
    }

    /**
     * �敪�R�[�h���擾����
     * @return String �敪�R�[�h
     */
    public String getDIVCD() {
        return (String) get(Tbj05EstimateItem.DIVCD);
    }

    /**
     * �敪�R�[�h��ݒ肷��
     * @param val String �敪�R�[�h
     */
    public void setDIVCD(String val) {
        set(Tbj05EstimateItem.DIVCD, val);
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
     * �f�[�^�쐬�������擾����
     * @return Date �f�[�^�쐬����
     */
    @XmlElement(required = true, nillable = true)
    public Date getCRTDATE() {
        return (Date) get(Tbj05EstimateItem.CRTDATE);
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     * @param val Date �f�[�^�쐬����
     */
    public void setCRTDATE(Date val) {
        set(Tbj05EstimateItem.CRTDATE, val);
    }

    /**
     * �f�[�^�쐬�҂��擾����
     * @return String �f�[�^�쐬��
     */
    public String getCRTNM() {
        return (String) get(Tbj05EstimateItem.CRTNM);
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     * @param val String �f�[�^�쐬��
     */
    public void setCRTNM(String val) {
        set(Tbj05EstimateItem.CRTNM, val);
    }

    /**
     * �쐬�v���O�������擾����
     * @return String �쐬�v���O����
     */
    public String getCRTAPL() {
        return (String) get(Tbj05EstimateItem.CRTAPL);
    }

    /**
     * �쐬�v���O������ݒ肷��
     * @param val String �쐬�v���O����
     */
    public void setCRTAPL(String val) {
        set(Tbj05EstimateItem.CRTAPL, val);
    }

    /**
     * �쐬�S����ID���擾����
     * @return String �쐬�S����ID
     */
    public String getCRTID() {
        return (String) get(Tbj05EstimateItem.CRTID);
    }

    /**
     * �쐬�S����ID��ݒ肷��
     * @param val String �쐬�S����ID
     */
    public void setCRTID(String val) {
        set(Tbj05EstimateItem.CRTID, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     * @return Date �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj05EstimateItem.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     * @param val Date �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj05EstimateItem.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     * @return String �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj05EstimateItem.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     * @param val String �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj05EstimateItem.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     * @return String �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj05EstimateItem.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     * @param val String �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj05EstimateItem.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     * @return String �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj05EstimateItem.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     * @param val String �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj05EstimateItem.UPDID, val);
    }

    /**
     * �敪�����擾����
     * @return String �敪��
     */
    public String getDIVNM() {
        return (String) get(Mbj17CrDivision.DIVNM);
    }

    /**
     * �敪����ݒ肷��
     * @param val String �敪��
     */
    public void setDIVNM(String val) {
        set(Mbj17CrDivision.DIVNM, val);
    }

    /**
     * �O���[�v�����擾����
     * @return String �O���[�v��
     */
    public String getGROUPNM() {
        return (String) get(Mbj26BillGroup.GROUPNM);
    }

    /**
     * �O���[�v����ݒ肷��
     * @param val String �O���[�v��
     */
    public void setGROUPNM(String val) {
        set(Mbj26BillGroup.GROUPNM, val);
    }

    /**
     * �R�[�v�敪�����擾����
     * @return String �R�[�v�敪��
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }

    /**
     * �R�[�v�敪����ݒ肷��
     * @param val String �R�[�v�敪��
     */
    public void setCODENAME(String val) {
        set(Mbj12Code.CODENAME, val);
    }

    /**
     * HC���喼���擾����
     * @return String HC���喼
     */
    public String getHCBUMONNM() {
        return (String) get(Mbj06HcBumon.HCBUMONNM);
    }

    /**
     * HC���喼��ݒ肷��
     * @param val String HC���喼
     */
    public void setHCBUMONNM(String val) {
        set(Mbj06HcBumon.HCBUMONNM, val);
    }

    /**
     * �X�֔ԍ����擾����
     * @return String �X�֔ԍ�
     */
    public String getPOSTNO() {
        return (String) get(Mbj06HcBumon.POSTNO);
    }

    /**
     * �X�֔ԍ���ݒ肷��
     * @param val String �X�֔ԍ�
     */
    public void setPOSTNO(String val) {
        set(Mbj06HcBumon.POSTNO, val);
    }

    /**
     * �Z���P���擾����
     * @return String �Z���P
     */
    public String getADDRESS1() {
        return (String) get(Mbj06HcBumon.ADDRESS1);
    }

    /**
     * �Z���P��ݒ肷��
     * @param val String �Z���P
     */
    public void setADDRESS1(String val) {
        set(Mbj06HcBumon.ADDRESS1, val);
    }

    /**
     * �Z���Q���擾����
     * @return String �Z���Q
     */
    public String getADDRESS2() {
        return (String) get(Mbj06HcBumon.ADDRESS2);
    }

    /**
     * �Z���Q��ݒ肷��
     * @param val String �Z���Q
     */
    public void setADDRESS2(String val) {
        set(Mbj06HcBumon.ADDRESS2, val);
    }

    /**
     * �����Ж����擾����
     * @return String �����Ж�
     */
    public String getBUMONCORPNM() {
        return (String) get(Mbj06HcBumon.BUMONCORPNM);
    }

    /**
     * �����Ж���ݒ肷��
     * @param val String �����Ж�
     */
    public void setBUMONCORPNM(String val) {
        set(Mbj06HcBumon.BUMONCORPNM, val);
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
    public BigDecimal getDtlPHASE() {
        return (BigDecimal) get(Tbj06EstimateDetail.PHASE);
    }

    /**
     * �t�F�C�Y��ݒ肷��
     * @param val BigDecimal �t�F�C�Y
     */
    public void setDtlPHASE(BigDecimal val) {
        set(Tbj06EstimateDetail.PHASE, val);
    }

    /**
     * �N�����擾����
     * @return Date �N��
     */
    @XmlElement(required = true, nillable = true)
    public Date getDtlCRDATE() {
        return (Date) get(Tbj06EstimateDetail.CRDATE);
    }

    /**
     * �N����ݒ肷��
     * @param val Date �N��
     */
    public void setDtlCRDATE(Date val) {
        set(Tbj06EstimateDetail.CRDATE, val);
    }

    /**
     * ���ψČ��Ǘ�NO���擾����
     * @return BigDecimal ���ψČ��Ǘ�NO
     */
    @XmlElement(required = true, nillable = true)
    public BigDecimal getDtlESTSEQNO() {
        return (BigDecimal) get(Tbj06EstimateDetail.ESTSEQNO);
    }

    /**
     * ���ψČ��Ǘ�NO��ݒ肷��
     * @param val BigDecimal ���ψČ��Ǘ�NO
     */
    public void setDtlESTSEQNO(BigDecimal val) {
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
     * ���i��(�T�u�j���擾����
     * @return String ���i��(�T�u�j
     */
    public String getPRODUCTNMSUB() {
        return (String) get(Tbj06EstimateDetail.PRODUCTNMSUB);
    }

    /**
     * ���i��(�T�u�j��ݒ肷��
     * @param val String ���i��(�T�u�j
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
     * ���i�}�̃R�[�h���擾����
     * @return String �}�̃R�[�h
     */
    public String getDtlMEDIACD() {
        return (String) get(Tbj06EstimateDetail.MEDIACD);
    }

    /**
     * ���i�}�̃R�[�h��ݒ肷��
     * @param val String �}�̃R�[�h
     */
    public void setDtlMEDIACD(String val) {
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
     * ���i�}�̖����擾����
     * @return String ���i�}�̖�
     */
    public String getDtlMEDIANM() {
        return (String) get(Mbj08HcProduct.MEDIANM);
    }

    /**
     * ���i�}�̖���ݒ肷��
     * @param val String ���i�}�̖�
     */
    public void setDtlMEDIANM(String val) {
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
     * �Č��}�̃R�[�h���擾����
     * @return String ���ϔ}�̃R�[�h
     */
    public String getMEDIACD() {
        return (String) get(Tbj03MediaMng.MEDIACD);
    }

    /**
     * �Č��}�̃R�[�h��ݒ肷��
     * @param val String �Č��}�̃R�[�h
     */
    public void setMEDIACD(String val) {
        set(Tbj03MediaMng.MEDIACD, val);
    }

    /**
     * �Č��}�̖����擾����
     * @return String �Č��}�̖�
     */
    public String getMEDIANM() {
        return (String) get(Mbj03Media.MEDIANM);
    }

    /**
     * �Č��}�̖���ݒ肷��
     * @param val String �Č��}�̖�
     */
    public void setMEDIANM(String val) {
        set(Mbj03Media.MEDIANM, val);
    }

    /**
     * �d�ʎԎ�R�[�h���擾����
     * @return String �d�ʎԎ�R�[�h
     */
    public String getDCARCD() {
        return (String) get(Tbj03MediaMng.DCARCD);
    }

    /**
     * �d�ʎԎ�R�[�h��ݒ肷��
     * @param val String �d�ʎԎ�R�[�h
     */
    public void setDCARCD(String val) {
        set(Tbj03MediaMng.DCARCD, val);
    }

    /**
     * �Ԏ햼���擾����
     * @return String �Ԏ햼
     */
    public String getCARNM() {
        return (String) get(Mbj05Car.CARNM);
    }

    /**
     * �Ԏ햼��ݒ肷��
     * @param val String �Ԏ햼
     */
    public void setCARNM(String val) {
        set(Mbj05Car.CARNM, val);
    }

    /**
     * ��p�v��No���擾����
     * @return String ��p�v��No
     */
    public String getHIYOUNO() {
        return (String) get(Mbj09Hiyou.HIYOUNO);
    }

    /**
     * ��p�v��No��ݒ肷��
     * @param val String ��p�v��No
     */
    public void setHIYOUNO(String val) {
        set(Mbj09Hiyou.HIYOUNO, val);
    }

    /* 2016/01/21 �����Ɩ��ύX�Ή� HLC K.Soga ADD Start */
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
    /* 2016/01/21 �����Ɩ��ύX�Ή� HLC K.Soga ADD End */
}