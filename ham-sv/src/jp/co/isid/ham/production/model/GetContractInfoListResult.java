package jp.co.isid.ham.production.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �_����擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/20 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class GetContractInfoListResult extends AbstractServiceResult {

    /* =============================================================================================*/
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }
    /* =============================================================================================*/

    /** �_����e�[�u��VO���X�g */
    private List<Tbj16ContractInfoVO> _tbj16ContractInfoVOList = null;

    /** �g�p�f�ޕ\���p(�^�����g�E�i���[�^�[)�f�[�^VO���X�g */
    private List<FindUseMaterialVO> _findUseMaterialTalentVOList = null;

    /** �g�p�f�ޕ\���p�f�[�^(�y��)VO���X�g */
    private List<FindUseMaterialVO> _findUseMaterialMusicVOList = null;

    /**
     * �_����e�[�u��VO���X�g���擾����
     * @return �_����e�[�u��VO���X�g
     */
    public List<Tbj16ContractInfoVO> getTbj16ContractInfoVOList() {
        return _tbj16ContractInfoVOList;
    }

    /**
     * �_����e�[�u��VO���X�g��ݒ肷��
     * @param tbj16ContractInfoVOList �_����e�[�u��VO���X�g
     */
    public void setTbj16ContractInfoVOList(List<Tbj16ContractInfoVO> tbj16ContractInfoVOList) {
        this._tbj16ContractInfoVOList = tbj16ContractInfoVOList;
    }

    /**
     * �g�p�f�ޕ\���p(�^�����g�E�i���[�^�[)�f�[�^���擾����
     * @return �g�p�f�ޕ\���p�f�[�^VO���X�g
     */
    public List<FindUseMaterialVO> getFindUseMaterialTalentVOList() {
        return _findUseMaterialTalentVOList;
    }

    /**
     * �g�p�f�ޕ\���p(�^�����g�E�i���[�^�[)�f�[�^��ݒ肷��
     * @param findUseMaterialVOList �g�p�f�ޕ\���p�f�[�^VO���X�g
     */
    public void setFindUseMaterialTalentVOList(List<FindUseMaterialVO> findUseMaterialTalentVOList) {
        this._findUseMaterialTalentVOList = findUseMaterialTalentVOList;
    }

    /**
     * �g�p�f�ޕ\���p(�y��)�f�[�^���擾����
     * @return �g�p�f�ޕ\���p�f�[�^VO���X�g
     */
    public List<FindUseMaterialVO> getFindUseMaterialMusicVOList() {
        return _findUseMaterialMusicVOList;
    }

    /**
     * �g�p�f�ޕ\���p(�y��)�f�[�^��ݒ肷��
     * @param findUseMaterialVOList �g�p�f�ޕ\���p�f�[�^VO���X�g
     */
    public void setFindUseMaterialMusicVOList(List<FindUseMaterialVO> findUseMaterialMusicVOList) {
        this._findUseMaterialMusicVOList = findUseMaterialMusicVOList;
    }
}

