package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR�����@�������s���̃f�[�^�擾�̌��ʃN���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class FindBudgetHistoryResult extends AbstractServiceResult {

    /* ============================================================================= */
    /** List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ǉ� */
    private String _dummy;

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B���擾���܂�
     *
     * @return String �_�~�[�v���p�e�B
     */
    public String getDummy() {
        return _dummy;
    }

    /**
     * List�����ł�Web�T�[�r�X�Ɍ��J����Ȃ��̂Ń_�~�[�v���p�e�B��ݒ肵�܂�
     *
     * @param dummy �_�~�[�v���p�e�B
     */
    public void setDummy(String dummy) {
        this._dummy = dummy;
    }

    /* ============================================================================= */

    /** FindBudgetHistoryVO���X�g */
    private List<FindBudgetHistoryVO> _findBudgetHistoryVoList = null;

    /**
     * FindBudgetHistoryVO���X�g���擾����
     *
     * @return FindBudgetHistoryVO���X�g
     */
    public List<FindBudgetHistoryVO> getFindBudgetHistoryVoList() {
        return _findBudgetHistoryVoList;
    }

    /**
     * FindBudgetHistoryVO���X�g��ݒ肷��
     *
     * @param findBudgetVoList FindBudgetHistoryVO���X�g
     */
    public void setFindBudgetHistoryVoList(List<FindBudgetHistoryVO> findBudgetHistoryVoList) {
        this._findBudgetHistoryVoList = findBudgetHistoryVoList;
    }

}
