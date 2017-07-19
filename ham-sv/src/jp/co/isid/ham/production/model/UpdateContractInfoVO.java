package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj17ContentVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentVO;


/**
 * <P>
 * �_����o�^�@�o�^���s���̓o�^�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/05 �VHAM�`�[��)<BR>
 * �EJASRAC�Ή�(2015/12/01 HLC S.Fujimoto)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class UpdateContractInfoVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** ��������VO */
    private UpdateContractInfoCondition _updateContractInfoCondition = null;

    /** �_���ށi�r���`�F�b�N�p�j */
    private String _exclusionCtrtkbnForContractInfo;

    /** �_��R�[�h�i�r���`�F�b�N�p�j */
    private String _exclusionCtrtnoForContractInfo;

    /** �_����o�^�̃^�C���X�^���v�ő�l */
    private Date _maxDateTimeForContractInfo = null;

    /** �_����VO�i�폜�j���X�g */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVOListDel = null;

    /** �_����VO�i�o�^�j���X�g */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVoListReg = null;

    /** �_����VO�i�X�V�j���X�g */
    private List<Tbj16ContractInfoUpdateVO> _tbj16ContractInfoUpdateVoListUpd = null;

    /** �f�ޓo�^���VO�i�폜�j���X�g */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVOListDel = null;

    /** �f�ޓo�^���VO�i�o�^�j���X�g */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVoListReg = null;

    /** �f�ޓo�^���VO�i�X�V�j���X�g */
    private List<Tbj18SozaiKanriDataVO> _tbj18SozaiKanriDataVoListUpd = null;

    /** �R���e���cVO */
    private List<Tbj17ContentVO> _tbj17ContentVo = null;

    /* 2015/12/01 JASRAC�Ή� HLC S.Fujimoto ADD Start */
    /** ���f�ޏ��o�^VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36InsVoList = null;
    /** ���f�ޏ��X�VVO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36UpdVoList = null;
    /** ���f�ޏ��폜VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36DelVoList = null;
    /** �_�񉼑f�ޕR�t���o�^VO */
    private List<Tbj40TempSozaiContentVO> _tbj40VoList = null;
    /* 2015/12/01 JASRAC�Ή� HLC S.Fujimoto ADD End */

    /**
     * �����������擾����
     *
     * @return ��������VO
     */
    public UpdateContractInfoCondition getUpdateContractInfoCondition() {
        return _updateContractInfoCondition;
    }

    /**
     * ����������ݒ肷��
     *
     * @param updateContractInfoCondition ��������VO
     */
    public void setUpdateContractInfoCondition(UpdateContractInfoCondition updateContractInfoCondition) {
        this._updateContractInfoCondition = updateContractInfoCondition;
    }

    /**
     * �_���ށi�r���`�F�b�N�p�j���擾����
     *
     * @return �_���ށi�r���`�F�b�N�p�j
     */
    public String getExclusionCtrtkbnForContractInfo() {
        return _exclusionCtrtkbnForContractInfo;
    }

    /**
     * �_���ށi�r���`�F�b�N�p�j��ݒ肷��
     *
     * @param exclusionCtrtkbnForContractInfo �_���ށi�r���`�F�b�N�p�j
     */
    public void setExclusionCtrtkbnForContractInfo(String exclusionCtrtkbnForContractInfo) {
        this._exclusionCtrtkbnForContractInfo = exclusionCtrtkbnForContractInfo;
    }

    /**
     * �_��R�[�h�i�r���`�F�b�N�p�j���擾����
     *
     * @return �_��R�[�h�i�r���`�F�b�N�p�j
     */
    public String getExclusionCtrtnoForContractInfo() {
        return _exclusionCtrtnoForContractInfo;
    }

    /**
     * �_��R�[�h�i�r���`�F�b�N�p�j��ݒ肷��
     *
     * @param exclusionCtrtnoForContractInfo �_��R�[�h�i�r���`�F�b�N�p�j
     */
    public void setExclusionCtrtnoForContractInfo(String exclusionCtrtnoForContractInfo) {
        this._exclusionCtrtnoForContractInfo = exclusionCtrtnoForContractInfo;
    }

    /**
     * �_����o�^�̃^�C���X�^���v�ő�l���擾����
     *
     * @return �_����o�^�̃^�C���X�^���v�ő�l
     */
    @XmlElement(required = true, nillable=true)
    public Date getMaxDateTimeForContractInfo() {
        return _maxDateTimeForContractInfo;
    }

    /**
     * �_����o�^�̃^�C���X�^���v�ő�l��ݒ肷��
     *
     * @param maxDateTimeForContractInfo �_����o�^�̃^�C���X�^���v�ő�l
     */
    public void setMaxDateTimeForContractInfo(Date maxDateTimeForContractInfo) {
        this._maxDateTimeForContractInfo = maxDateTimeForContractInfo;
    }

    /**
     * �_����VO�i�폜�j���X�g���擾����
     *
     * @return �_����VO�i�폜�j���X�g
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListDel() {
        return _tbj16ContractInfoUpdateVOListDel;
    }

    /**
     * �_����VO�i�폜�j���X�g��ݒ肷��
     *
     * @param tbj16ContractInfoUpdateVoListDel �_����VO�i�폜�j���X�g
     */
    public void setTbj16ContractInfoUpdateVOListDel(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListDel) {
        this._tbj16ContractInfoUpdateVOListDel = tbj16ContractInfoUpdateVoListDel;
    }

    /**
     * �_����VO�i�o�^�j���X�g���擾����
     *
     * @return �_����VO�i�o�^�j���X�g
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListReg() {
        return _tbj16ContractInfoUpdateVoListReg;
    }

    /**
     * �_����VO�i�o�^�j��ݒ肷��
     *
     * @param tbj16ContractInfoUpdateVoListReg �_����VO�i�o�^�j���X�g
     */
    public void setTbj16ContractInfoUpdateVOListReg(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListReg) {
        this._tbj16ContractInfoUpdateVoListReg = tbj16ContractInfoUpdateVoListReg;
    }

    /**
     * �_����VO�i�X�V�j���X�g���擾����
     *
     * @return �_����VO�i�X�V�j���X�g
     */
    public List<Tbj16ContractInfoUpdateVO> getTbj16ContractInfoUpdateVOListUpd() {
        return _tbj16ContractInfoUpdateVoListUpd;
    }

    /**
     * �_����VO�i�X�V�j���X�g��ݒ肷��
     *
     * @param tbj16ContractInfoUpdateVoListUpd �_����VO�i�X�V�j���X�g
     */
    public void setTbj16ContractInfoUpdateVOListUpd(List<Tbj16ContractInfoUpdateVO> tbj16ContractInfoUpdateVoListUpd) {
        this._tbj16ContractInfoUpdateVoListUpd = tbj16ContractInfoUpdateVoListUpd;
    }

//    /**
//     * �f�ޓo�^���VO�i�X�V�j���X�g���擾����
//     *
//     * @return �f�ޓo�^���VO�i�X�V�j���X�g
//     */
//    public List<Tbj18SozaiKanriDataUpdateVO> getTbj18SozaiKanriDataUpdateVO() {
//        return _tbj18SozaiKanriDataUpdateVO;
//    }
//
//    /**
//     * �f�ޓo�^���VO�i�X�V�j���X�g��ݒ肷��
//     *
//     * @param tbj18SozaiKanriDataUpdateVO �f�ޓo�^���VO�i�X�V�j���X�g
//     */
//    public void setTbj18SozaiKanriDataUpdateVO(List<Tbj18SozaiKanriDataUpdateVO> tbj18SozaiKanriDataUpdateVO) {
//        this._tbj18SozaiKanriDataUpdateVO = tbj18SozaiKanriDataUpdateVO;
//    }

    /**
     * �f�ޓo�^���VO�i�폜�j���X�g���擾����
     *
     * @return �f�ޓo�^���VO�i�폜�j���X�g
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListDel() {
        return _tbj18SozaiKanriDataVOListDel;
    }

    /**
     * �f�ޓo�^���VO�i�폜�j���X�g��ݒ肷��
     *
     * @param tbj18SozaiKanriDataVoListDel �f�ޓo�^���VO�i�폜�j���X�g
     */
    public void setTbj18SozaiKanriDataVOListDel(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListDel) {
        this._tbj18SozaiKanriDataVOListDel = tbj18SozaiKanriDataVoListDel;
    }

    /**
     * �f�ޓo�^���VO�i�o�^�j���X�g���擾����
     *
     * @return �f�ޓo�^���VO�i�o�^�j���X�g
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListReg() {
        return _tbj18SozaiKanriDataVoListReg;
    }

    /**
     * �f�ޓo�^���VO�i�o�^�j��ݒ肷��
     *
     * @param tbj18SozaiKanriDataVoListReg �f�ޓo�^���VO�i�o�^�j���X�g
     */
    public void setTbj18SozaiKanriDataVOListReg(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListReg) {
        this._tbj18SozaiKanriDataVoListReg = tbj18SozaiKanriDataVoListReg;
    }

    /**
     * �f�ޓo�^���VO�i�X�V�j���X�g���擾����
     *
     * @return �f�ޓo�^���VO�i�X�V�j���X�g
     */
    public List<Tbj18SozaiKanriDataVO> getTbj18SozaiKanriDataVOListUpd() {
        return _tbj18SozaiKanriDataVoListUpd;
    }

    /**
     * �f�ޓo�^���VO�i�X�V�j���X�g��ݒ肷��
     *
     * @param tbj18SozaiKanriDataVoListUpd �f�ޓo�^���VO�i�X�V�j���X�g
     */
    public void setTbj18SozaiKanriDataVOListUpd(List<Tbj18SozaiKanriDataVO> tbj18SozaiKanriDataVoListUpd) {
        this._tbj18SozaiKanriDataVoListUpd = tbj18SozaiKanriDataVoListUpd;
    }

    /**
     * �R���e���cVO���X�g���擾����
     *
     * @return �R���e���cVO���X�g
     */
    public List<Tbj17ContentVO> getTbj17ContentVo() {
        return _tbj17ContentVo;
    }

    /**
     * �R���e���cVO���X�g��ݒ肷��
     *
     * @param tbj17ContentVo �R���e���cVO
     */
    public void setTbj17ContentVo(List<Tbj17ContentVO> tbj17ContentVo) {
        this._tbj17ContentVo = tbj17ContentVo;
    }

    /* 2015/12/01 JASRAC�Ή� HLC S.Fujimoto ADD Start */
    /**
     * ���f�ޏ��o�^VO���擾����
     * @return List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��o�^VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36InsVoList() {
        return _tbj36InsVoList;
    }

    /**
     * ���f�ޏ��o�^VO��ݒ肷��
     * @param val List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��o�^VO
     */
    public void setTbj36InsVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36InsVoList = val;
    }

    /**
     * ���f�ޏ��X�VVO���擾����
     * @return List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��o�^VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36UpdVoList() {
        return _tbj36UpdVoList;
    }

    /**
     * ���f�ޏ��X�VVO��ݒ肷��
     * @param val List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��X�VVO
     */
    public void setTbj36UpdVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36UpdVoList = val;
    }

    /**
     * ���f�ޏ��폜VO���擾����
     * @return List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��폜VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36DelVoList() {
        return _tbj36DelVoList;
    }

    /**
     * ���f�ޏ��폜VO��ݒ肷��
     * @param val List<Tbj36TempSozaiKanriDataVO> ���f�ޏ��폜VO
     */
    public void setTbj36DelVoList(List<Tbj36TempSozaiKanriDataVO> val) {
        _tbj36DelVoList = val;
    }

    /**
     * �_�񉼑f�ޕR�t���o�^VO���擾����
     * @return List<Tbj40TempSozaiContentVO> �_�񉼑f�ޕR�t���o�^VO
     */
    public List<Tbj40TempSozaiContentVO> getTbj40VoList() {
        return _tbj40VoList;
    }

    /**
     * �_�񉼑f�ޕR�t���o�^VO��ݒ肷��
     * @param val List<Tbj40TempSozaiContentVO> �_�񉼑f�ޕR�t���o�^VO
     */
    public void setTbj40VoList(List<Tbj40TempSozaiContentVO> val) {
        _tbj40VoList = val;
    }
    /* 2015/12/01 JASRAC�Ή� HLC S.Fujimoto ADD End */

}
