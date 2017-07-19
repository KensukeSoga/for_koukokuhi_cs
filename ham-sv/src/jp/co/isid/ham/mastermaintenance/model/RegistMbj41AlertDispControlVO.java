package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

import jp.co.isid.ham.common.model.RegistExclusionVO;
import jp.co.isid.ham.common.model.Mbj41AlertDispControlVO;

/**
 * <P>
 * �A���[�g�\������o�^�f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/07/05 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class RegistMbj41AlertDispControlVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �r�����b�N���VO */
    RegistExclusionVO _exclusion;

    /** �f�[�^VO�}�����X�g */
    private List<Mbj41AlertDispControlVO> _insertList;

    /** �f�[�^VO�X�V���X�g */
    private List<Mbj41AlertDispControlVO> _updateList;

    /** �f�[�^VO�폜���X�g */
    private List<Mbj41AlertDispControlVO> _deleteList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public RegistMbj41AlertDispControlVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new RegistMbj41AlertDispControlVO();
    }

    /**
     * �r�����b�N���VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _exclusion
     */
    public void setExclusion(RegistExclusionVO vo)
    {
        _exclusion = vo;
    }

    /**
     * �r�����b�N���VO���擾���܂�
     * @return _exclusion
     */
    public RegistExclusionVO getExclusion()
    {
        return _exclusion;
    }

    /**
     * �f�[�^VO�}�����X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _insertList
     */
    public void setInsertList(List<Mbj41AlertDispControlVO> voList)
    {
        _insertList = voList;
    }

    /**
     * �f�[�^VO�}�����X�g���擾���܂�
     * @return _insertList
     */
    public List<Mbj41AlertDispControlVO> getInsertList()
    {
        return _insertList;
    }

    /**
     * �f�[�^VO�X�V���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _updateList
     */
    public void setUpdateList(List<Mbj41AlertDispControlVO> voList)
    {
        _updateList = voList;
    }

    /**
     * �f�[�^VO�X�V���X�g���擾���܂�
     * @return _updateList
     */
    public List<Mbj41AlertDispControlVO> getUpdateList()
    {
        return _updateList;
    }

    /**
     * �f�[�^VO�폜���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _deleteList
     */
    public void setDeleteList(List<Mbj41AlertDispControlVO> voList)
    {
        _deleteList = voList;
    }

    /**
     * �f�[�^VO�폜���X�g���擾���܂�
     * @return _deleteList
     */
    public List<Mbj41AlertDispControlVO> getDeleteList()
    {
        return _deleteList;
    }

    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ���ݒ肵�܂�
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy)
    {
        _dummy = dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ����擾���܂�
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy()
    {
        return _dummy;
    }

}