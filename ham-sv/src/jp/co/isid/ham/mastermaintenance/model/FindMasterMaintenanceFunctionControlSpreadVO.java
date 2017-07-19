package jp.co.isid.ham.mastermaintenance.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �@�\����X�v���b�h�����f�[�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/11 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceFunctionControlSpreadVO extends AbstractModel
{
    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �f�[�^VO���X�g */
    private List<MasterMaintenanceFunctionControlSpreadVO> _findList;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public FindMasterMaintenanceFunctionControlSpreadVO()
    {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance()
    {
        return new FindMasterMaintenanceFunctionControlSpreadVO();
    }

    /**
     * �f�[�^VO���X�g��ݒ肵�܂�
     * @param voList �Z�b�g���� _findList
     */
    public void setFindList(List<MasterMaintenanceFunctionControlSpreadVO> voList)
    {
        _findList = voList;
    }

    /**
     * �f�[�^VO���X�g���擾���܂�
     * @return _findList
     */
    public List<MasterMaintenanceFunctionControlSpreadVO> getFindList()
    {
        return _findList;
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
