package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �_����o�^���Update�N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/18 �VHAM�`�[��)<BR>
 * �EHDX�Ή�(2016/02/24 HLC K.Oki)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateContractInfoCondition implements Serializable {
    /**
    *
    */
   private static final long serialVersionUID = 1L;

   /** �_����*/
   private String strCtrtKbn;
   /** �_����(��)*/
   private String strCtrtKbnOld;
    /** �_��R�[�h*/
   private String strCtrtNo;
    /** �Ԏ�R�[�h*/
   private String StrCarCd;
    /** �J�e�S��*/
   private String StrCategory;
    /** �l���A�A�[�e�B�X�g*/
   private String StrNames;
    /** ����(From)*/
   private Date DtDateFrom;
    /** ����(To)*/
   private Date DtDateTo;
    /** �y��*/
   private String StrMusic;
    /** JASRAC�o�^�t���O*/
   private String StrJasracFlg;
    /** CD�����t���O*/
   private String StrSaleFlg;
   /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
    /** �Ԃ牺����t���O*/
   private String StrEndtitleFlg;
    /** �A�����W�E�I���W�i���E�t���O*/
   private String StrArrgOrgFlg;
   /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */
    /** ���l*/
   private String StrBiko;
    /** �f�[�^�쐬����*/
   private Date DtCrtDate;
    /** �f�[�^�쐬��*/
   private String StrCrtNm;
    /** �f�[�^�X�V����*/
   private Date DtUpdDate;
    /** �f�[�^�X�V��*/
   private String StrUpdNm;
    /** �X�V�v���O����*/
   private String StrUpdApl;
    /** �X�V�S����*/
   private String StrUpdId;
    /** 10��CM�R�[�h*/
   private String StrCmCd;

    /**
     * �_���ނ��擾����
     *
     * @return �_����
     */
    public String getStrCtrtKbn() {
        return strCtrtKbn;
    }

    /**
     * �_���ނ�ݒ肷��
     *
     * @param strCtrtKbn �_����
     */
    public void setStrCtrtKbn(String strCtrtKbn) {
        this.strCtrtKbn = strCtrtKbn;
    }

    /**
     * �_��R�[�h���擾����
     *
     * @return �_��R�[�h
     */
    public String getStrCtrtNo() {
        return strCtrtNo;
    }

    /**
     * �_��R�[�h��ݒ肷��
     *
     * @param strCtrtNo �_��R�[�h
     */
    public void setStrCtrtNo(String strCtrtNo) {
        this.strCtrtNo = strCtrtNo;
    }

    /**
     * �Ԏ�R�[�h���擾����
     *
     * @return �Ԏ�R�[�h
     */
    public String getStrCarCd() {
        return StrCarCd;
    }

    /**
     * �Ԏ�R�[�h��ݒ肷��
     *
     * @param StrCarCd �Ԏ�R�[�h
     */
    public void setStrCarCd(String StrCarCd) {
        this.StrCarCd = StrCarCd;
    }

    /**
     * �J�e�S�����擾����
     *
     * @return �J�e�S��
     */
    public String getStrCategory() {
        return StrCategory;
    }

    /**
     * �J�e�S����ݒ肷��
     *
     * @param strCategory �J�e�S��
     */
    public void setStrCategory(String strCategory) {
        StrCategory = strCategory;
    }

    /**
     * �l���A�A�[�e�B�X�g���擾����
     *
     * @return �l���A�A�[�e�B�X�g
     */
    public String getStrNames() {
        return StrNames;
    }

    /**
     * �l���A�A�[�e�B�X�g��ݒ肷��
     *
     * @param �l���A�A�[�e�B�X�g
     */
    public void setStrNames(String strNames) {
        StrNames = strNames;
    }

    /**
     * ����(From)���擾����
     *
     * @return ����(From)
     */
    public Date getDtDateFrom() {
        return DtDateFrom;
    }

    /**
     * ����(From)��ݒ肷��
     *
     * @param DtDateFrom ����(From)
     */
    public void setDtDateFrom(Date dtDateFrom) {
        DtDateFrom = dtDateFrom;
    }

    /**
     * ����(To)���擾����
     *
     * @return ����(To)
     */
    public Date getDtDateTo() {
        return DtDateTo;
    }

    /**
     * ����(To)��ݒ肷��
     *
     * @param DtDateTo ����(To)
     */
    public void setDtDateTo(Date dtDateTo) {
        DtDateTo = dtDateTo;
    }

    /**
     * �y�Ȃ��擾����
     *
     * @return �y��
     */
    public String getStrMusic() {
        return StrMusic;
    }

    /**
     * �y�Ȃ�ݒ肷��
     *
     * @param �y��
     */
    public void setStrMusic(String strMusic) {
        StrMusic = strMusic;
    }

    /**
     * JASRAC�o�^�t���O���擾����
     *
     * @return JASRAC�o�^
     */
    public String getStrJasracFlg() {
        return StrJasracFlg;
    }

    /**
     * JASRAC�o�^�t���O��ݒ肷��
     *
     * @param JASRAC�o�^
     */
    public void setStrJasracFlg(String strJasracFlg) {
        StrJasracFlg = strJasracFlg;
    }

    /**
     * CD�����o�^�t���O���擾����
     *
     * @return CD�����o�^�t���O
     */
    public String getStrSaleFlg() {
        return StrSaleFlg;
    }

    /**
     * CD�����o�^�t���O��ݒ肷��
     *
     * @param strSaleFlg CD�����o�^�t���O
     */
    public void setStrSaleFlg(String strSaleFlg) {
        StrSaleFlg = strSaleFlg;
    }

    /* 2016/02/24 HDX�Ή� HLC K.Oki ADD Start */
    /**
     * �Ԃ牺����t���O���擾����
     *
     * @return �Ԃ牺����t���O���擾����
     */
    public String getStrEndtitleFlg() {
        return StrEndtitleFlg;
    }

    /**
     * �Ԃ牺����t���O��ݒ肷��
     *
     * @param strEndtitleFlg �Ԃ牺����t���O
     */
    public void setStrEndtitleFlg(String strEndtitleFlg) {
        StrEndtitleFlg = strEndtitleFlg;
    }

    /**
     * �A�����W�E�I���W�i���t���O���擾����
     *
     * @return �A�����W�E�I���W�i���t���O���擾����
     */
    public String getArrgOrgFlg() {
        return StrArrgOrgFlg;
    }

    /**
     * �A�����W�E�I���W�i���t���O��ݒ肷��
     *
     * @param strArrgOrgFlg �A�����W�E�I���W�i���t���O
     */
    public void setArrgOrgFlg(String strArrgOrgFlg) {
        StrArrgOrgFlg = strArrgOrgFlg;
    }
    /* 2016/02/24 HDX�Ή� HLC K.Oki ADD End */

    /**
     * ���l���擾����
     *
     * @return ���l
     */
   public String getStrBiko() {
       return StrBiko;
   }

    /**
     * ���l��ݒ肷��
     *
     * @param strBiko ���l
     */
    public void setStrBiko(String strBiko) {
        StrBiko = strBiko;
    }

    /**
     * �f�[�^�쐬�������擾����
     *
     * @return �f�[�^�쐬����
     */
    public Date getDtCrtDate() {
        return DtCrtDate;
    }

    /**
     * �f�[�^�쐬������ݒ肷��
     *
     * @param DtCrtDate �f�[�^�쐬����
     */
    public void setDtCrtDate(Date dtCrtDate) {
        DtCrtDate = dtCrtDate;
    }

    /**
     * �f�[�^�쐬�҂��擾����
     *
     * @return �f�[�^�쐬��
     */
    public void setStrCrtNm(String strCrtNm) {
        StrCrtNm = strCrtNm;
    }

    /**
     * �f�[�^�쐬�҂�ݒ肷��
     *
     * @param StrCrtNm �f�[�^�쐬��
     */
    public String getStrCrtNm() {
        return StrCrtNm;
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    public Date getDtUpdDate() {
        return DtUpdDate;
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param DtUpdDate �f�[�^�X�V����
     */
    public void setDtUpdDate(Date dtUpdDate) {
        DtUpdDate = dtUpdDate;
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getStrUpdNm() {
        return StrUpdNm;
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param StrUpdNm �f�[�^�X�V��
     */
    public void setStrUpdNm(String strUpdNm) {
        StrUpdNm = strUpdNm;
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getStrUpdApl() {
        return StrUpdApl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param strUpdApl �X�V�v���O����
     */
    public void setStrUpdApl(String strUpdApl) {
        StrUpdApl = strUpdApl;
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getStrUpdId() {
        return StrUpdId;
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param strUpdId �X�V�S����ID
     */
    public void setStrUpdId(String strUpdId) {
        StrUpdId = strUpdId;
    }

    /**
     * �_����(��)���擾����
     *
     * @return strCtrtKbnOld �_����(��)
     */
    public String getStrCtrtKbnOld() {
        return strCtrtKbnOld;
    }

    /**
     * �_����(��)��ݒ肷��
     *
     * @param strCtrtKbnOld �_����(��)
     */
    public void setStrCtrtKbnOld(String strCtrtKbnOld) {
        this.strCtrtKbnOld = strCtrtKbnOld;
    }

    /**
     * 10��CM�R�[�h���擾����
     *
     * @return strCmCd 10��CM�R�[�h
     */
    public String getStrCmCd() {
        return StrCmCd;
    }

    /**
     * 10��CM�R�[�h��ݒ肷��
     *
     * @param strCmCd 10��CM�R�[�h
     */
    public void setStrCmCd(String strCmCd) {
        this.StrCmCd = strCmCd;
    }
}
