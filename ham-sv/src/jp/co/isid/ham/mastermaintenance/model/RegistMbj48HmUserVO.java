package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;
import jp.co.isid.ham.common.model.Mbj48HmUserVO;
import jp.co.isid.ham.common.model.RegistExclusionVO;

/**
 * <P>
 * HM�S���ғo�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMbj48HmUserVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �r�����b�N���VO */
    RegistExclusionVO _exclusion;

    /** �f�[�^VO�ǉ����X�g */
    private List<Mbj48HmUserVO> _insertList;

    /** �f�[�^VO�X�V���X�g */
    private List<Mbj48HmUserVO> _updateList;

    /** �f�[�^VO�폜���X�g */
    private List<Mbj48HmUserVO> _deleteList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMbj48HmUserVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new RegistMbj48HmUserVO();
    }

    /**
     * �r�����b�N���VO��ݒ肷��
     * @param vo �Z�b�g���� _exclusion
     */
    public void setExclusion(RegistExclusionVO vo) {
        _exclusion = vo;
    }

    /**
     * �r�����b�N���VO���擾����
     * @return _exclusion
     */
    public RegistExclusionVO getExclusion() {
        return _exclusion;
    }

    /**
     * �f�[�^VO�ǉ����X�g��ݒ肷��
     * @param voList List<Mbj48HmUserVO> �f�[�^VO�ǉ����X�g
     */
    public void setInsertList(List<Mbj48HmUserVO> voList) {
        _insertList = voList;
    }

    /**
     * �f�[�^VO�ǉ����X�g���擾����
     * @return List<Mbj48HmUserVO> �f�[�^VO�ǉ����X�g
     */
    public List<Mbj48HmUserVO> getInsertList() {
        return _insertList;
    }

    /**
     * �f�[�^VO�X�V���X�g��ݒ肷��
     * @param voList List<Mbj48HmUserVO> �f�[�^VO�X�V���X�g
     */
    public void setUpdateList(List<Mbj48HmUserVO> voList) {
        _updateList = voList;
    }

    /**
     * �f�[�^VO�X�V���X�g���擾����
     * @return List<Mbj48HmUserVO> �f�[�^VO�X�V���X�g
     */
    public List<Mbj48HmUserVO> getUpdateList() {
        return _updateList;
    }

    /**
     * �f�[�^VO�폜���X�g��ݒ肷��
     * @param voList List<Mbj48HmUserVO> �f�[�^VO�폜���X�g
     */
    public void setDeleteList(List<Mbj48HmUserVO> voList) {
        _deleteList = voList;
    }

    /**
     * �f�[�^VO�폜���X�g���擾����
     * @return List<Mbj48HmUserVO> �f�[�^VO�폜���X�g
     */
    public List<Mbj48HmUserVO> getDeleteList() {
        return _deleteList;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肷��
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        _dummy = dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾����
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

}
